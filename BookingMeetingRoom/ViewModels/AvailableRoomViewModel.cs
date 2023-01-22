using System.Transactions;

namespace BookingMeetingRoom.ViewModels
{
    public class AvailableRoomViewModel
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string RoomImage { get; set; }
        public string Seat { get; set;}
        public string RoomFacilities { get; set; }
        public string RoomAvailableDay { get; set; }
        public string RoomAvailableTime { get; set; }
        public string RoomFloor { get; set; }
        public string Remark { get; set; }
    }
}
