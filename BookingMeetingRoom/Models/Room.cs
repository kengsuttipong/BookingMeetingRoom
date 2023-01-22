using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMeetingRoom.Models
{
    public partial class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string ImageName { get; set; }
        public int? Capacity { get; set; }
        public int? StatusId { get; set; }
        public string Remark { get; set; }
        public int? FloorId { get; set; }
        public string AvailableFrom { get; set; }
        public string AvailableTo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
