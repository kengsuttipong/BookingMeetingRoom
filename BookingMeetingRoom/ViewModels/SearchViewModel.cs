using System;

namespace BookingMeetingRoom.ViewModels
{
    public class SearchViewModel
    {
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public string EndTime { get; set; }
        public int Person { get; set; }
    }
}
