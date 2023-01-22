using BookingMeetingRoom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BookingMeetingRoom.ClassDB;
using BookingMeetingRoom.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BookingMeetingRoom.Controllers
{
    public class RoomController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly BookingMeetingRoomContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        ClassGetDB _db = new ClassGetDB();
        FillModelFromDB _fillModel = new FillModelFromDB();

        public RoomController(IConfiguration configuration, BookingMeetingRoomContext context, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int id = 1)
        {
            RoomViewModel _roomViewModel = new RoomViewModel();
            DataTable _dt = new DataTable();
            SortedList _param = new SortedList();
            _param.Add("id", id);

            _dt = await _db.GetSqlRecord("[sprocGetRoomDetail]", _configuration, _param);

            if (_dt != null)
            {
                _roomViewModel = _fillModel.FillRoom(_dt);
            }

            if (_roomViewModel == null)
            {
                return NotFound();
            }

            return View(_roomViewModel);
        }

        //Edit
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            RoomViewModel _roomViewModel = new RoomViewModel();
            DataTable _dt = new DataTable();
            SortedList _param = new SortedList();
            _param.Add("id", id);

            _dt = await _db.GetSqlRecord("[sprocGetRoomDetail]", _configuration, _param);

            if (_dt != null)
            {
                _roomViewModel = _fillModel.FillEditRoom(_dt);
            }

            if (_roomViewModel == null)
            {
                return NotFound();
            }

            ViewData["DayOfWeekLists"] = new SelectList(_context.DayOfWeekMasters, "DayOfWeekId", "DayOfWeek");
            ViewData["FacilitiesLists"] = new SelectList(_context.Facilities, "FacilitiesId", "FacilitiesName");
            ViewData["FloorLists"] = new SelectList(_context.Floors, "FloorId", "FloorName", _roomViewModel.FloorID);
            ViewData["StatusLists"] = new SelectList(_context.RoomStatuses, "RoomStatusId", "StatusName", _roomViewModel.StatusID);

            return View(_roomViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,RoomViewModel data)
        {
            try
            {
                if (id != data.RoomId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    RoomViewModel _roomViewModel = new RoomViewModel();
                    var user = await _userManager.GetUserAsync(User);
                    var userId = user.Id;
                    SortedList _param = new SortedList();
                    _param.Add("@RoomId", id);
                    _param.Add("@RoomName", data.RoomName);
                    _param.Add("@AvailableBookDay", data.AvailableBookDayId);
                    _param.Add("@AvailableFrom", data.AvailableFrom);
                    _param.Add("@AvailableTo", data.AvailableTo);
                    _param.Add("@Facilities", data.FacilitiesId);
                    _param.Add("@Seat", data.Seat);
                    _param.Add("@FloorID", data.FloorID);
                    _param.Add("@Remark", data.Remark);
                    _param.Add("@Status", data.StatusID);
                    _param.Add("@userId", userId);

                    Int64 result = await _db.InsertUpdateRecord("sprocInsertUpdateRoom", _configuration, _param);

                    if (result > 0)
                    {
                        ViewBag.JavaScriptFunction = string.Format("mySweetAlert('{0}', '{1}', '{2}', {3});", "", "Saved Success.", "success", 400);
                    }
                    else
                    {
                        ViewBag.JavaScriptFunction = string.Format("mySweetAlert('{0}', '{1}', '{2}', {3});", "", "Something wrong.", "error", 400);
                    }

                    ViewData["DayOfWeekLists"] = new SelectList(_context.DayOfWeekMasters, "DayOfWeekId", "DayOfWeek");
                    ViewData["FacilitiesLists"] = new SelectList(_context.Facilities, "FacilitiesId", "FacilitiesName");
                    ViewData["FloorLists"] = new SelectList(_context.Floors, "FloorId", "FloorName", _roomViewModel.FloorID);
                    ViewData["StatusLists"] = new SelectList(_context.RoomStatuses, "RoomStatusId", "StatusName", _roomViewModel.StatusID);
                }
            }
            catch (Exception ex)
            {
                ViewBag.JavaScriptFunction = string.Format("mySweetAlert('{0}', '{1}', '{2}', {3});", "", ex.Message.ToString(), "error", 400);
            }     

            return View(data);
        }
        //Edit


        //Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["DayOfWeekLists"] = new SelectList(_context.DayOfWeekMasters, "DayOfWeekId", "DayOfWeek");
            ViewData["FacilitiesLists"] = new SelectList(_context.Facilities, "FacilitiesId", "FacilitiesName");
            ViewData["FloorLists"] = new SelectList(_context.Floors, "FloorId", "FloorName");
            ViewData["StatusLists"] = new SelectList(_context.RoomStatuses, "RoomStatusId", "StatusName");

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomViewModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RoomViewModel _roomViewModel = new RoomViewModel();
                    var user = await _userManager.GetUserAsync(User);
                    var userId = user.Id;
                    SortedList _param = new SortedList();
                    _param.Add("@RoomId", 0);
                    _param.Add("@RoomName", data.RoomName);
                    _param.Add("@AvailableBookDay", data.AvailableBookDayId);
                    _param.Add("@AvailableFrom", data.AvailableFrom);
                    _param.Add("@AvailableTo", data.AvailableTo);
                    _param.Add("@Facilities", data.FacilitiesId);
                    _param.Add("@Seat", data.Seat);
                    _param.Add("@FloorID", data.FloorID);
                    _param.Add("@Remark", data.Remark == null ? "" : data.Remark);
                    _param.Add("@Status", data.StatusID);
                    _param.Add("@userId", userId);

                    Int64 result = await _db.InsertUpdateRecord("sprocInsertUpdateRoom", _configuration, _param);

                    if (result > 0)
                    {
                        ViewBag.JavaScriptFunction = string.Format("mySweetAlert('{0}', '{1}', '{2}', {3});", "", "Saved Success.", "success", 400);
                    }
                    else
                    {
                        ViewBag.JavaScriptFunction = string.Format("mySweetAlert('{0}', '{1}', '{2}', {3});", "", "Something wrong.", "error", 400);
                    }

                    ViewData["DayOfWeekLists"] = new SelectList(_context.DayOfWeekMasters, "DayOfWeekId", "DayOfWeek");
                    ViewData["FacilitiesLists"] = new SelectList(_context.Facilities, "FacilitiesId", "FacilitiesName");
                    ViewData["FloorLists"] = new SelectList(_context.Floors, "FloorId", "FloorName", _roomViewModel.FloorID);
                    ViewData["StatusLists"] = new SelectList(_context.RoomStatuses, "RoomStatusId", "StatusName", _roomViewModel.StatusID);
                }
            }
            catch (Exception ex)
            {
                ViewBag.JavaScriptFunction = string.Format("mySweetAlert('{0}', '{1}', '{2}', {3});", "", ex.Message.ToString(), "error", 400);
            }

            return View(data);
        }
        //Create
    }
}
