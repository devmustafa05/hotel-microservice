using HotelManager.Application.Features.Hotels.Command.UpdateHotel;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelContacts.Command.UpdateHotelContact
{
    internal class UpdateHotelContactCommandHandler : IRequestHandler<UpdateHotelContactCommandRequest, Unit>
    {
        IUnitOfWork unitOfWork;
        private IMapper mapper;
        public UpdateHotelContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateHotelContactCommandRequest request, CancellationToken cancellationToken)
        {
            var hotelContact = await unitOfWork.GetReadRepostory<HotelContact>().GetAsync(
              predicate: x => x.IsActive && !x.IsDeleted
                            && x.Id == request.Id);



            if (hotelContact == null)
            {
                throw new NotFoundException("Hotel contact not found");
            }

            var map = mapper.Map<HotelContact, UpdateHotelContactCommandRequest>(request);
            map.IsActive = true;
            map.IsDeleted = false;
            map.CreatedDate = hotelContact.CreatedDate;

            await unitOfWork.GetWriteRepostory<HotelContact>().UpdateAsync(map);
            var result = await unitOfWork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Hotel Contact updated failed. Changes could not be saved.");
            }
            return Unit.Value;
        }
    }
}
