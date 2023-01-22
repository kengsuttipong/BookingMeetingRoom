using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMeetingRoom.Models
{
    public partial class RoomStatus
    {
        public int RoomStatusId { get; set; }
        public string StatusName { get; set; }
        public string StatusType { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
