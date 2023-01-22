using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace BookingMeetingRoom.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string TelNumber { get; set; }
        public string ImageName { get; set; }
        public bool IsDelete { get; set; }

    }
}
