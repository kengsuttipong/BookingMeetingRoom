using BookingMeetingRoom.Models;
using System.Linq;

namespace BookingMeetingRoom.ViewModels
{
    public partial class RoomListsViewModel
    {
        public IQueryable<Room> RoomLists { get; set; }
    }
}
