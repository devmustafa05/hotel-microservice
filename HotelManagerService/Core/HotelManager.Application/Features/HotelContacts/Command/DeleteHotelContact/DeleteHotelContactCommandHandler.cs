using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace HotelManager.Application.Features.HotelContacts.Command.DeleteHotelContact
{
    public class DeleteHotelContactCommandHandler : IRequestHandler<DeleteHotelContactCommandRequest, Unit>
    {

        private readonly IUnitOfWork unitofwork;
        public DeleteHotelContactCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitofwork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteHotelContactCommandRequest request, CancellationToken cancellationToken)
        {
            var hotelContact = await unitofwork.GetReadRepostory<HotelContact>().GetAsync(
                   predicate: x => x.IsActive && !x.IsDeleted
                                 && x.Id == request.Id);

            if (hotelContact == null)
            {
                throw new NotFoundException("Hotel contact not found");
            }

            await unitofwork.GetWriteRepostory<HotelContact>().SoftDeleteAsync(hotelContact);

            var result = await unitofwork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Hotel contact deletion failed. Ensure the record exists and is not linked to other entities.");
            }
            return Unit.Value;
        }
    }
}
