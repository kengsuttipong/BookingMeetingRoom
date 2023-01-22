using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMeetingRoom.Models
{
    public partial class RoomAvailableBooking
    {
        public int RoomAvailableBookingId { get; set; }
        public int RoomId { get; set; }
        public int DayOfWeekId { get; set; }
    }
}
