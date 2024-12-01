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
            var hotelLocationContact = await unitOfWork.GetReadRepostory<HotelLocationContact>().GetAsync(
              predicate: x => x.IsActive && !x.IsDeleted
                            && x.Id == request.Id);

            var map = mapper.Map<HotelLocationContact, UpdateHotelLocationContactCommandRequest>(request);
            map.IsActive = true;
            map.IsDeleted = false;

            await unitOfWork.GetWriteRepostory<HotelLocationContact>().UpdateAsync(map);
            var result = await unitOfWork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Hotel location contact updated failed. Changes could not be saved.");
            }
            return Unit.Value;
        }
    }
}
