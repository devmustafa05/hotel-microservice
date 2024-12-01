using HotelManager.Application.Features.Hotels.Rules;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace HotelManager.Application.Features.Hotels.Command.UpdateHotel
{
    public  class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommandRequest, Unit>
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        private readonly HotelRules hotelRules;
        public UpdateHotelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, HotelRules hotelRules)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.hotelRules = hotelRules;

        }
        public async Task<Unit> Handle(UpdateHotelCommandRequest request, CancellationToken cancellationToken)
        {
            var queryableHotels = await unitOfWork.GetReadRepostory<Hotel>()
                                .GetWhere(predicate: x => x.IsActive && !x.IsDeleted);

            await hotelRules.HotelTitleMustNotBeSame(queryableHotels, request.Name);

            var hotel = queryableHotels.FirstOrDefault(x => x.Id == request.Id);

            if (hotel == null)
            {
                throw new NotFoundException("Hotel not found");
            }

            var map = mapper.Map<Hotel, UpdateHotelCommandRequest>(request);
            map.IsActive = true;
            map.IsDeleted = false;

            await unitOfWork.GetWriteRepostory<Hotel>().UpdateAsync(map);
            var result = await unitOfWork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Hotel updated failed. Changes could not be saved.");
            }
            return Unit.Value;
        }
    }
}
