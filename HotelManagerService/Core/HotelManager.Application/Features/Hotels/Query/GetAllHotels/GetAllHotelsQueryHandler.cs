using HotelManager.Application.DTOs.Hotels;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManager.Application.Features.Hotels.Query.GetAllHotels
{
    public class GetAllHotelsQueryHandler : IRequestHandler<GetAllHotelsQueryRequest, IList<GetAllHotelsQueryResponse>>
    {
        IUnitOfWork unitofWork;
        IMapper mapper;
        public GetAllHotelsQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllHotelsQueryResponse>> Handle(GetAllHotelsQueryRequest request, CancellationToken cancellationToken)
        {
            var hotels = await unitofWork.GetReadRepostory<Hotel>().GetAllAsync(
              predicate: x => x.IsActive && !x.IsDeleted,
               include: q => q
                .Include(h => h.HotelOfficials)
                .Include(h => h.HotelContacts)
                .Include(h => h.HotelLocationContacts));

            await unitofWork.GetWriteRepostory<Hotel>().AddARangAsync(hotels);

             mapper.Map<HotelOfficialDto, HotelOfficial>(new List<HotelOfficial>());
             mapper.Map<HotelContactsDto, HotelContact>(new List<HotelContact>());
             mapper.Map<HotelLocationContactDto, HotelLocationContact>(new List<HotelLocationContact>());

            var map = mapper.Map<GetAllHotelsQueryResponse, Hotel>(hotels);
            return map;
        }
    }
}
