﻿using HotelManager.Application.Features.HotelOfficials.Command.CreateHotelOfficial;
using HotelManager.Application.Features.Hotels.Command.CreateHotel;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelContacts.Command.CreateHotelContact
{
    public class CreateHotelLocationContactCommandHandler : IRequestHandler<CreateHotelLocationContactCommandRequest, Unit>
    {
        IUnitOfWork unitOfWork;
        private IMapper mapper;

        public CreateHotelLocationContactCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(CreateHotelLocationContactCommandRequest request, CancellationToken cancellationToken)
        {
            var hotelLocationContact = mapper.Map<HotelLocationContact, CreateHotelLocationContactCommandRequest>(request);

            await unitOfWork.GetWriteRepostory<HotelLocationContact>().AddAsync(hotelLocationContact);
            var result = await unitOfWork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Hotel Location Contact creation failed. Changes could not be saved.");
            }
            return Unit.Value;
        }
    }
}
