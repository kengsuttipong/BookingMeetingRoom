using System;

namespace BookingMeetingRoom.ViewModels
{
    public class BookingIndexViewModel
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomImage { get; set; }
        public string Seat { get; set; }
        public string RoomFacilities { get; set; }
        public string RoomAvailableDay { get; set; }
        public string RoomAvailableTime { get; set; }
        public string RoomFloor { get; set; }
        public string Remark { get; set; }
        public int Objective { get; set; }
        public string ObjectiveText { get; set; }
        public DateTime BookingDate { get; set;}
        public string BookingStartTime { get; set; }
        public string BookingEndTime { get; set; }
        public string? MoreRequest { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BookingFor { get; set; }

    }
}
