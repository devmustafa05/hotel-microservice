using HotelManager.Application.Features.Hotels.Command.UpdateHotel;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelContacts.Command.UpdateHotelContact
{
    internal class UpdateHotelLocationContactCommandHandler : IRequestHandler<UpdateHotelLocationContactCommandRequest, Unit>
    {
        IUnitOfWork unitOfWork;
        private IMapper mapper;
        public UpdateHotelLocationContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateHotelLocationContactCommandRequest request, CancellationToken cancellationToken)
        {
            var hotelLocationContacts = await unitOfWork.GetReadRepostory<ContactLocationMapping>().GetAllAsync(
                predicate: x => x.IsActive && !x.IsDeleted
                            && x.HotelId == request.HotelId);

            if (request.LocationIds != null)
            {
                throw new Exception("Is null empty LocationIds");
            }

            await unitOfWork.GetWriteRepostory<ContactLocationMapping>()
                .HardDeleteRangeAsync(hotelLocationContacts);


            foreach (var locationId in request.LocationIds)
            {
                await unitOfWork.GetWriteRepostory<ContactLocationMapping>()
                    .AddAsync(new()
                    {
                        HotelId = request.HotelId,
                        LocationId = locationId
                    });
            }
           
            var result = await unitOfWork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Hotel location contact updated failed. Changes could not be saved.");
            }
            return Unit.Value;
        }
    }
}
