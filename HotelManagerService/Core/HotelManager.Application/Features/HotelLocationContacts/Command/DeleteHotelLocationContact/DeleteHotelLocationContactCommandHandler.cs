using HotelManager.Application.Features.Hotels.Command.DeleteHotel;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelContacts.Command.DeleteHotelContact
{
    public class DeleteHotelLocationContactCommandHandler : IRequestHandler<DeleteHotelContactCommandRequest, Unit>
    {

        private readonly IUnitOfWork unitofwork;
        public DeleteHotelLocationContactCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitofwork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteHotelContactCommandRequest request, CancellationToken cancellationToken)
        {
            var hotelLocationContact = await unitofwork.GetReadRepostory<HotelLocationContact>().GetAsync(
                   predicate: x => x.IsActive && !x.IsDeleted
                                 && x.Id == request.Id);

            await unitofwork.GetWriteRepostory<HotelLocationContact>().SoftDeleteAsync(hotelLocationContact);

            var result = await unitofwork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Hotel location contact deletion failed. Ensure the record exists and is not linked to other entities.");
            }
            return Unit.Value;
        }
    }
}
