using HotelManager.Application.Features.Hotels.Command.CreateHotel;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;

namespace HotelManager.Application.Features.HotelContacts.Command.CreateHotelContact
{
    public class CreateHotelContactCommandHandler : IRequestHandler<CreateHotelContactCommandRequest, Unit>
    {
        IUnitOfWork unitOfWork;
        private IMapper mapper;

        public CreateHotelContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(CreateHotelContactCommandRequest request, CancellationToken cancellationToken)
        {
            var hotelContact = mapper.Map<HotelContact, CreateHotelContactCommandRequest>(request);

            await unitOfWork.GetWriteRepostory<HotelContact>().AddAsync(hotelContact);
            var result = await unitOfWork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Hotel contact creation failed. Changes could not be saved.");
            }
            return Unit.Value;
        }
    }
}
