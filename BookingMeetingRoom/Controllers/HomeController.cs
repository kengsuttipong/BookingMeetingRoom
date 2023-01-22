using BookingMeetingRoom.ClassDB;
using BookingMeetingRoom.Models;
using BookingMeetingRoom.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookingMeetingRoom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        ClassGetDB _db = new ClassGetDB();
        FillModelFromDB _fillModel = new FillModelFromDB();

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var mainIndexViewModel = new MainIndexViewModel();
            var _dt = new DataTable();

            var model = new SearchViewModel
            {
                StartDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
                EndDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
                StartTime = "09:00",
                EndTime = "18:00",
                Person = 2
            };

            _dt = await _db.GetSqlRecord("sprocGetAvailableRoomNow", _configuration, null);

            mainIndexViewModel.SearchViewModel = model;

            if (_dt != null)
            {
                mainIndexViewModel.AvailableRoomNowViewModel = await _fillModel.FillAvailableRoomNow(_dt);
            }

            return View(mainIndexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(MainIndexViewModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AvailableRoomViewModel _availableRoomViewModel = new AvailableRoomViewModel();
                    MainIndexViewModel mainIndexViewModel = new MainIndexViewModel();

                    var _dtSearch = new DataTable();
                    var _dtRecommend = new DataTable();
                    SortedList _param = new SortedList();
                    _param.Add("@StartDate", data.SearchViewModel.StartDate);
                    _param.Add("@StartTime", data.SearchViewModel.StartTime);
                    _param.Add("@EndDate", data.SearchViewModel.EndDate);
                    _param.Add("@EndTime", data.SearchViewModel.EndTime);
                    _param.Add("@Person", data.SearchViewModel.Person);

                    _dtSearch = await _db.GetSqlRecord("sprocGetAvailableRoom", _configuration, _param);

                    if (_dtSearch != null)
                    {
                        mainIndexViewModel.AvailableRoomViewModel = await _fillModel.FillAvailableRoom(_dtSearch);
                    }

                    _dtRecommend = await _db.GetSqlRecord("sprocGetAvailableRoomNow", _configuration, null);

                    if (_dtRecommend != null) 
                    {
                        mainIndexViewModel.AvailableRoomNowViewModel = await _fillModel.FillAvailableRoomNow(_dtRecommend);
                    }

                    if (mainIndexViewModel == null)
                    {
                        return NotFound();
                    }

                    return View("Index", mainIndexViewModel);
                }

                return View("Index", data);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
