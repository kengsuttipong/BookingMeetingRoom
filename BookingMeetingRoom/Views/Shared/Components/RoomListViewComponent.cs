using BookingMeetingRoom.Models;
using BookingMeetingRoom.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingMeetingRoom.Views.Shared.Components
{
    [ViewComponent(Name = "RoomLists")]
    public class RoomListViewComponent : ViewComponent
    {
        private readonly BookingMeetingRoomContext _db;

        public RoomListViewComponent(BookingMeetingRoomContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roomListsViewModel = new RoomListsViewModel()
            {
                RoomLists = _db.Rooms
            };
            
            return View(roomListsViewModel);
        }
    }
}
