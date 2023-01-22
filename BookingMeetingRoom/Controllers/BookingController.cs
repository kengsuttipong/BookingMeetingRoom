using BookingMeetingRoom.ClassDB;
using BookingMeetingRoom.Models;
using BookingMeetingRoom.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace BookingMeetingRoom.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingMeetingRoomContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        ClassGetDB _db = new ClassGetDB();
        FillModelFromDB _fillModel = new FillModelFromDB();

        public BookingController(BookingMeetingRoomContext context, IConfiguration configuration, UserManager<ApplicationUser> userManager) 
        {
            _context = context;
            _configuration = configuration;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index(int id)
        {

            BookingIndexViewModel _bookingViewModel = new BookingIndexViewModel();
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;
            DataTable _dt = new DataTable();
            SortedList _param = new SortedList();
            _param.Add("@id", id);           

            _dt = await _db.GetSqlRecord("[sprocGetRoomDetail]", _configuration, _param);

            if (_dt != null)
            {                
                _bookingViewModel = await _fillModel.FillBookingIndex(_dt);
                _bookingViewModel.BookingDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                _bookingViewModel.BookingStartTime = DateTime.Now.ToString("HH:mm");
                _bookingViewModel.BookingEndTime = DateTime.Now.ToString("HH:mm");
                _bookingViewModel.Email = user.Email;
                _bookingViewModel.PhoneNumber= user.PhoneNumber;
                _bookingViewModel.FullName = user.FullName;
                _bookingViewModel.Position = user.Position;
                _bookingViewModel.Department = user.Department;
            }

            if (_bookingViewModel == null)
            {
                return NotFound();
            }

            ViewData["ObjectiveLists"] = new SelectList(_context.Objectives, "ObjectiveId", "ObjectiveName");

            return View(_bookingViewModel);
        }

        public IActionResult Confirm(BookingIndexViewModel data) 
        {
            var objective = _context.Objectives.Where(o => o.ObjectiveId == data.Objective).FirstOrDefault();

            data.ObjectiveText = objective.ObjectiveName;

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmProcess(BookingIndexViewModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var userId = user.Id;
                    DataTable _dt = new DataTable();
                    SortedList _param = new SortedList();
                    _param.Add("@userId", userId);
                    _param.Add("@RoomId", data.RoomId);
                    _param.Add("@Objective", data.Objective);
                    _param.Add("@StartTime", data.BookingDate.ToString("yyyy-MM-dd") + " " + data.BookingStartTime);
                    _param.Add("@EndTime", data.BookingDate.ToString("yyyy-MM-dd") + " " + data.BookingEndTime);
                    _param.Add("@MoreRequest", data.MoreRequest ?? "");
                    _param.Add("@BookingFor", data.BookingFor);
                    _param.Add("@FullName", data.FullName);
                    _param.Add("@Email", data.Email);
                    _param.Add("@PhoneNumber", data.PhoneNumber);
                    _param.Add("@Position", data.Position);
                    _param.Add("@Department", data.Department);

                    Int64 result = await _db.InsertUpdateRecord("sprocInsertBooking", _configuration, _param);

                    if (result >= 0)
                    {
                        ViewBag.JavaScriptFunction = string.Format("mySweetAlert('{0}', '{1}', '{2}', {3});", "", "Saved Success.", "success", 400);

                        return RedirectToAction("History", "Booking", new { type = "Success" });
                    }
                    else
                    {
                        ViewBag.JavaScriptFunction = string.Format("mySweetAlert('{0}', '{1}', '{2}', {3});", "", "Something wrong.", "error", 400);

                        return RedirectToAction("Confirm", data);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.JavaScriptFunction = string.Format("mySweetAlert('{0}', '{1}', '{2}', {3});", "", ex.Message.ToString(), "error", 400);
            }

            return RedirectToAction("History", "Booking", new { type = "Success" });
        }

        public IActionResult History(string type)
        {
            if (type == "Success")
            {
                ViewBag.JavaScriptFunction = string.Format("ClickShowToast();");
            }

            return View();
        }
    }
}
