using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application.Features.HotelOfficials.Command.DeleteHotelOfficial
{
    public class DeleteHotelOfficialContactCommandHandler : IRequestHandler<DeleteHotelOfficialCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitofwork;
        public DeleteHotelOfficialContactCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitofwork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteHotelOfficialCommandRequest request, CancellationToken cancellationToken)
        {
            var hotelOfficial = await unitofwork.GetReadRepostory<HotelOfficial>().GetAsync(
                   predicate: x => x.IsActive && !x.IsDeleted
                                 && x.Id == request.Id);

            if (hotelOfficial == null)
            {
                throw new NotFoundException("Hotel official contact not found");
            }

            await unitofwork.GetWriteRepostory<HotelOfficial>().SoftDeleteAsync(hotelOfficial);


            var result = await unitofwork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Hotel official deletion failed. Ensure the record exists and is not linked to other entities.");
            }
            return Unit.Value;
        }
    }
}
