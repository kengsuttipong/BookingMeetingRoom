using System.ComponentModel.DataAnnotations;

namespace BookingMeetingRoom.ViewModels
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Room Name can not be blank")]
        public string RoomName { get; set; }
        public string AvailableBookDay { get; set; }
        public string AvailableBookDayId { get; set; }
        public string AvailableFrom { get; set; }
        public string AvailableTo { get; set; }
        public int Seat { get; set; }
        public string Facilities { get; set; }
        public string FacilitiesId { get; set; }
        public string Status { get; set; }
        public int StatusID { get; set; }
        public string Remark { get; set; }
        public string Floor { get; set; }
        public int FloorID { get; set; }
    }
}
