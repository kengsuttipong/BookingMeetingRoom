using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMeetingRoom.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public string UserId { get; set; }
        public int? RoomId { get; set; }
        public int? StatusId { get; set; }
        public int? ValidatedBy { get; set; }
        public int? ObjectiveId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Note { get; set; }
    }
}
