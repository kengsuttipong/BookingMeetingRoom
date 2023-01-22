using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMeetingRoom.Models
{
    public partial class ImageRoom
    {
        public int ImageRoomId { get; set; }
        public int? RoomId { get; set; }
        public string ImageName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
