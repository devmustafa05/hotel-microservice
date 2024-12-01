using HotelManager.Application.DTOs.Hotels;
using HotelManager.Application.Interfaces.AutoMapper;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;

namespace HotelManager.Application.Features.Hotels.Query.GetHotelById
{
    public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQueryRequest, GetHotelByIdQueryResponse>
    {
        IUnitOfWork unitofWork;
        IMapper mapper;
        public GetHotelByIdQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }
        public async Task<GetHotelByIdQueryResponse> Handle(GetHotelByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var hotel = await unitofWork.GetReadRepostory<Hotel>().GetAsync(
            predicate: x => x.IsActive && !x.IsDeleted
                          && x.Id == request.HotelId,
               include: q => q
               .Include(h => h.HotelOfficials)
               .Include(h => h.HotelContacts)
               .Include(h => h.HotelLocationContacts));

            mapper.Map<HotelOfficialDto, HotelOfficial>(new List<HotelOfficial>());
            mapper.Map<HotelContactsDto, HotelContact>(new List<HotelContact>());
            mapper.Map<HotelLocationContactDto, HotelLocationContact>(new List<HotelLocationContact>());

            var map = mapper.Map<GetHotelByIdQueryResponse, Hotel>(hotel);

            if (map == null)
            {
                throw new NotFoundException("Hotel not found");
            }

            return map;
        }
    }
}
