using HotelManager.Application.DTOs.Hotels;
using HotelManager.Application.Features.Hotels.Query.GetAllHotels;
using HotelManager.Application.Features.Hotels.Query.GetHotelById;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.Hotels.Command.UpdateHotel
{
    public  class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommandRequest, Unit>
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public UpdateHotelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }

        public async Task<Unit> Handle(UpdateHotelCommandRequest request, CancellationToken cancellationToken)
        {  
            var hotel = await unitOfWork.GetReadRepostory<Hotel>().GetAsync(
              predicate: x => x.IsActive && !x.IsDeleted
                            && x.Id == request.Id);

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

            return Unit.Value;
        }
    }
}
