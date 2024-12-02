using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using HotelManager.Domain.Enums;
using MediatR;

namespace HotelManager.Application.Features.LocationReport.Ouery.GetLocationHotel
{
    public class GetLocationHotelQueryHandler : IRequestHandler<GetLocationHotelQueryRequest, GetLocationHotelQueryResponse>
    {
        IUnitOfWork unitofWork;
        public GetLocationHotelQueryHandler(IUnitOfWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }
        public async Task<GetLocationHotelQueryResponse> Handle(GetLocationHotelQueryRequest request, CancellationToken cancellationToken)
        {

            // TODO:Mustafa Buradan devam edicem

            var contactLocationMapping = await unitofWork.GetReadRepostory<ContactLocationMapping>().GetAllAsync(
              predicate: x => x.IsActive && !x.IsDeleted);

            var hotelLocationContactIds = contactLocationMapping.Select(s => s.HotelLocationContactId).ToList();


            var hotelLocationContacts = await unitofWork.GetReadRepostory<HotelLocationContact>().GetAllAsync(
              predicate: x => x.IsActive && !x.IsDeleted);

            var hotelIds = hotelLocationContacts.GroupBy(s => s.HotelId).Select(s => s.Key).ToList();

            var hotelContactPhoneNumber =  unitofWork.GetReadRepostory<HotelContact>().GetAllAsync(
                    predicate: x => x.IsActive && !x.IsDeleted
                                && hotelIds.Contains(x.HotelId)
                                && x.HotelContactType == HotelContactType.PhoneNumber).Result;

            var phoneNumbers = hotelContactPhoneNumber.GroupBy(s => s.Content).Select(s => s.Key).ToList();


            GetLocationHotelQueryResponse response = new GetLocationHotelQueryResponse();

            response.HotelCount = hotelIds.Count();
            response.PhoneNumberCount = phoneNumbers.Count();
            return response;
        }
    }
}
