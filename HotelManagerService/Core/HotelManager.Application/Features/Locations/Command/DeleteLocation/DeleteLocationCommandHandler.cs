using HotelManager.Application.Features.Hotels.Command.DeleteHotel;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelContacts.Command.DeleteHotelContact
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationContactRequest, Unit>
    {

        private readonly IUnitOfWork unitofwork;
        public DeleteLocationCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitofwork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteLocationContactRequest request, CancellationToken cancellationToken)
        {
            var location = await unitofwork.GetReadRepostory<Location>().GetAsync(
                   predicate: x => x.IsActive && !x.IsDeleted
                                 && x.Id == request.Id);

            if (location == null)
            {
                throw new NotFoundException("Location not found");
            }

            await unitofwork.GetWriteRepostory<Location>().SoftDeleteAsync(location);

            var result = await unitofwork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("location deletion failed. Ensure the record exists and is not linked to other entities.");
            }
            return Unit.Value;
        }
    }
}
