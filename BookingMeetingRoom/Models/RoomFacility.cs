using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMeetingRoom.Models
{
    public partial class RoomFacility
    {
        public int RoomFacilitiesId { get; set; }
        public int? FacilitiesId { get; set; }
        public int? RoomId { get; set; }
        public bool? IsDelete { get; set; }
    }
}
