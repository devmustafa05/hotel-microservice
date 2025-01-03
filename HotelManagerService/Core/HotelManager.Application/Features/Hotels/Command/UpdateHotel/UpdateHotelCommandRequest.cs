﻿using MediatR;

namespace HotelManager.Application.Features.Hotels.Command.UpdateHotel
{
    public class UpdateHotelCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string LocationName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
