using HotelManager.Application.DTOs.Hotels;
using HotelManager.Application.Features.Hotels.Rules;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;

namespace HotelManager.Application.Features.Hotels.Command.CreateHotel
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommandRequest, Unit>
    {
        IUnitOfWork unitOfWork;
        private IMapper mapper;
        private readonly HotelRules hotelRules;
        public CreateHotelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, HotelRules hotelRules)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.hotelRules = hotelRules;
        }
        public async Task<Unit> Handle(CreateHotelCommandRequest request, CancellationToken cancellationToken)
        {   
            mapper.Map<HotelOfficial , HotelOfficialCreationRequest>(new List<HotelOfficialCreationRequest>());
            mapper.Map<HotelContact, HotelContactCreationRequest>(new List<HotelContactCreationRequest>());
            mapper.Map<HotelLocationContact, HotelLocationContactCreationRequest>(new List<HotelLocationContactCreationRequest>());

            var hotel = mapper.Map<Hotel, CreateHotelCommandRequest>(request);
            var queryableHotels = await unitOfWork.GetReadRepostory<Hotel>()
                                    .GetWhere(predicate: x => x.IsActive && !x.IsDeleted);

            await hotelRules.HotelTitleMustNotBeSame(queryableHotels, request.Name);

            await unitOfWork.GetWriteRepostory<Hotel>().AddAsync(hotel);
            var result = await unitOfWork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Hotel creation failed. Changes could not be saved.");
            }
            return Unit.Value;
        }
    }
}
