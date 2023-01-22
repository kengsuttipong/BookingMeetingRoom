using System;
using System.Collections.Generic;

#nullable disable

namespace BookingMeetingRoom.Models
{
    public partial class Floor
    {
        public int FloorId { get; set; }
        public string FloorName { get; set; }
        public bool? IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
