﻿using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;

namespace HotelManager.Application.Features.HotelOfficials.Command.CreateHotelOfficial
{
    public class CreateHotelOfficialCommandHandler : IRequestHandler<CreateHotelOfficialCommandRequest, Unit>
    {
        IUnitOfWork unitOfWork;
        private IMapper mapper;

        public CreateHotelOfficialCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    

        public async Task<Unit> Handle(CreateHotelOfficialCommandRequest request, CancellationToken cancellationToken)
        {
            var hotelOfficial = mapper.Map<HotelOfficial, CreateHotelOfficialCommandRequest>(request);
            
            await unitOfWork.GetWriteRepostory<HotelOfficial>().AddAsync(hotelOfficial);
            var result = await unitOfWork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Hotel Official creation failed. Changes could not be saved.");
            }
            return Unit.Value;
        }
    }
}


   

