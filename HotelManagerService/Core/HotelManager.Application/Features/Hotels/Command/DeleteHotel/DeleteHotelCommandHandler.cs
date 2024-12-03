using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;

namespace HotelManager.Application.Features.Hotels.Command.DeleteHotel

{
    public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommandRequest, Unit>
    {

        private readonly IUnitOfWork unitofwork;
        public DeleteHotelCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitofwork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteHotelCommandRequest request, CancellationToken cancellationToken)
        {
            var hotel = await unitofwork.GetReadRepostory<Hotel>().GetAsync(
            predicate: x => x.IsActive && !x.IsDeleted
                          && x.Id == request.Id,
             include: q => q
              .Include(h => h.HotelOfficials)
              .Include(h => h.HotelContacts));

            if (hotel == null)
            {
                throw new NotFoundException("Hotel not found");
            }

            await unitofwork.GetWriteRepostory<Hotel>().SoftDeleteAsync(hotel);

            var hotelOfficials = hotel.HotelOfficials.ToList();
            if (hotelOfficials is not null && hotelOfficials.Count() > 0)
            {
                await unitofwork.GetWriteRepostory<HotelOfficial>().SoftDeleteRangeAsync(hotelOfficials);
            }

            var hotelContacts = hotel.HotelContacts.ToList();
            if (hotelContacts is not null && hotelContacts.Count() > 0)
            {
                await unitofwork.GetWriteRepostory<HotelContact>().SoftDeleteRangeAsync(hotelContacts);
            }

            // mapping tablosundan silme yapılabilir
            
            var result = await unitofwork.SaveAsync();

            if (result <= 0)
            {
                throw new Exception("Hotel deletion failed. Ensure the record exists and is not linked to other entities.");
            }
            return Unit.Value;
        }
    }
}
