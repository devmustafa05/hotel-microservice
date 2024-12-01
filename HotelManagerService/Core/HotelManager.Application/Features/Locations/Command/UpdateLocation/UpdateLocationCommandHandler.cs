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
    internal class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommandRequest, Unit>
    {
        IUnitOfWork unitOfWork;
        private IMapper mapper;
        public UpdateLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var location = await unitOfWork.GetReadRepostory<Location>().GetAsync(
                predicate: x => x.IsActive && !x.IsDeleted
                            && x.Id == request.Id);

            if (location == null)
            {
                throw new NotFoundException("Location not found");
            }

            var map = mapper.Map<Location, UpdateLocationCommandRequest>(request);
            map.IsActive = true;
            map.IsDeleted = false;
            map.UpdatedDate = location.UpdatedDate;

            await unitOfWork.GetWriteRepostory<Location>().UpdateAsync(map);
            var result = await unitOfWork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Location updated failed. Changes could not be saved.");
            }
            return Unit.Value;
        }
    }
}
