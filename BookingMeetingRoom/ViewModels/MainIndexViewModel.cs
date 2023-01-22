using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace BookingMeetingRoom.ViewModels
{
    public class MainIndexViewModel
    {
        public SearchViewModel SearchViewModel { get; set; }

        public IEnumerable<AvailableRoomViewModel> AvailableRoomViewModel { get; set; }
        public IEnumerable<AvailableRoomNowViewModel> AvailableRoomNowViewModel { get; set; }
    }
}
