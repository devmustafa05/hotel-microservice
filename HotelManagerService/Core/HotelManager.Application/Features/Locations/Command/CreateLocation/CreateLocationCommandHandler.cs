using HotelManager.Application.Features.HotelOfficials.Command.CreateHotelOfficial;
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

namespace HotelManager.Application.Features.HotelContacts.Command.Locations
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommandRequest, Unit>
    {
        IUnitOfWork unitOfWork;
        private IMapper mapper;

        public CreateLocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(CreateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            var locations = mapper.Map<Location, CreateLocationCommandRequest>(request);

            await unitOfWork.GetWriteRepostory<Location>().AddAsync(locations);
            var result = await unitOfWork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Location creation failed. Changes could not be saved.");
            }
            return Unit.Value;
        }
    }
}
