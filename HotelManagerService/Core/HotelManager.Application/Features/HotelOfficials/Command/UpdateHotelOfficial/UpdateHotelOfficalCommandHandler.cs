using HotelManager.Application.Features.HotelContacts.Command.UpdateHotelContact;
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

namespace HotelManager.Application.Features.HotelOfficials.Command.UpdateHotelOfficial
{
    public class UpdateHotelOfficalCommandHandler : IRequestHandler<UpdateHotelOfficalCommandRequest, Unit>
    {
        IUnitOfWork unitOfWork;
        private IMapper mapper;
        public UpdateHotelOfficalCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateHotelOfficalCommandRequest request, CancellationToken cancellationToken)
        {
            var hotelOfficial = await unitOfWork.GetReadRepostory<HotelOfficial>().GetAsync(
              predicate: x => x.IsActive && !x.IsDeleted
                            && x.Id == request.Id);

            if (hotelOfficial == null)
            {
                throw new NotFoundException("Hotel official contact not found");
            }

            var map = mapper.Map<HotelOfficial, UpdateHotelOfficalCommandRequest>(request);
            map.HotelId = hotelOfficial.HotelId;


            map.IsActive = true;
            map.IsDeleted = false;

            await unitOfWork.GetWriteRepostory<HotelOfficial>().UpdateAsync(map);
            var result = await unitOfWork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Hotel Official updated failed. Changes could not be saved.");
            }
            return Unit.Value;
        }
    }
}
