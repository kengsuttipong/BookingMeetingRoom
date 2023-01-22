using BookingMeetingRoom.Models;
using System.Data;
using System;
using BookingMeetingRoom.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingMeetingRoom.ClassDB
{
    public class FillModelFromDB
    {
        public RoomViewModel FillRoom(DataTable _dt)
        {
            RoomViewModel _roomViewModel = new RoomViewModel();

            foreach (DataRow dr in _dt.Rows)
            {
                _roomViewModel.RoomId = Int16.Parse(dr["RoomID"].ToString());
                _roomViewModel.RoomName = dr["RoomName"].ToString();
                _roomViewModel.AvailableBookDay = dr["AvailableDay"].ToString();
                _roomViewModel.AvailableFrom = dr["AvailableFrom"].ToString();
                _roomViewModel.AvailableTo = dr["AvailableTo"].ToString();
                _roomViewModel.Seat = Int16.Parse(dr["Seat"].ToString());
                _roomViewModel.Facilities = dr["FacilitiesName"].ToString();
                _roomViewModel.Status = dr["StatusName"].ToString();
                _roomViewModel.StatusID = Int16.Parse(dr["statusID"].ToString());
                _roomViewModel.Remark = dr["Remark"].ToString();
                _roomViewModel.Floor = dr["FloorName"].ToString();
            }

            return _roomViewModel;
        }

        public RoomViewModel FillEditRoom(DataTable _dt)
        {
            RoomViewModel _roomViewModel = new RoomViewModel();

            foreach (DataRow dr in _dt.Rows)
            {
                _roomViewModel.RoomId = Int16.Parse(dr["RoomID"].ToString());
                _roomViewModel.RoomName = dr["RoomName"].ToString();
                _roomViewModel.AvailableBookDay = dr["AvailableDay"].ToString();
                _roomViewModel.AvailableBookDayId = dr["AvailableDayId"].ToString();
                _roomViewModel.AvailableFrom = dr["AvailableFrom"].ToString();
                _roomViewModel.AvailableTo = dr["AvailableTo"].ToString();
                _roomViewModel.Seat = Int16.Parse(dr["Seat"].ToString());
                _roomViewModel.Facilities = dr["FacilitiesName"].ToString();
                _roomViewModel.FacilitiesId = dr["FacilitiesId"].ToString();
                _roomViewModel.Status = dr["StatusName"].ToString();
                _roomViewModel.StatusID = Int16.Parse(dr["StatusID"].ToString());
                _roomViewModel.Remark = dr["Remark"].ToString();
                _roomViewModel.Floor = dr["FloorName"].ToString();
                _roomViewModel.FloorID = Int16.Parse(dr["FloorID"].ToString());
            }

            return _roomViewModel;
        }

        public async Task<List<AvailableRoomViewModel>> FillAvailableRoom(DataTable _dt)
        {
            var _list = new List<AvailableRoomViewModel>();

            foreach (DataRow dr in _dt.Rows)
            {
                var _availableRoomViewModel = new AvailableRoomViewModel();
                _availableRoomViewModel.RoomId = Int16.Parse(dr["RoomID"].ToString());
                _availableRoomViewModel.RoomName = dr["RoomName"].ToString();
                _availableRoomViewModel.RoomImage = dr["RoomImage"].ToString();
                _availableRoomViewModel.Seat = dr["Seat"].ToString();
                _availableRoomViewModel.RoomFacilities = dr["RoomFacilities"].ToString();
                _availableRoomViewModel.RoomAvailableDay = dr["RoomAvailableDay"].ToString();
                _availableRoomViewModel.RoomAvailableTime = dr["RoomAvailableTime"].ToString();
                _availableRoomViewModel.RoomFloor = dr["FloorName"].ToString();
                _availableRoomViewModel.Remark = dr["Remark"].ToString();

                await Task.Run(() => _list.Add(_availableRoomViewModel));
            }

            return _list;
        }

        public async Task<List<AvailableRoomNowViewModel>> FillAvailableRoomNow(DataTable _dt)
        {
            var _list = new List<AvailableRoomNowViewModel>();

            foreach (DataRow dr in _dt.Rows)
            {
                var _availableRoomNowViewModel = new AvailableRoomNowViewModel();
                _availableRoomNowViewModel.RoomId = Int16.Parse(dr["RoomID"].ToString());
                _availableRoomNowViewModel.RoomName = dr["RoomName"].ToString();
                _availableRoomNowViewModel.RoomImage = dr["RoomImage"].ToString();
                _availableRoomNowViewModel.Seat = dr["Seat"].ToString();
                _availableRoomNowViewModel.RoomFacilities = dr["RoomFacilities"].ToString();
                _availableRoomNowViewModel.RoomAvailableDay = dr["RoomAvailableDay"].ToString();
                _availableRoomNowViewModel.RoomAvailableTime = dr["RoomAvailableTime"].ToString();
                _availableRoomNowViewModel.RoomFloor = dr["FloorName"].ToString();
                _availableRoomNowViewModel.Remark = dr["Remark"].ToString();

                await Task.Run(() => _list.Add(_availableRoomNowViewModel));
            }

            return _list;
        }

        public async Task<BookingIndexViewModel> FillBookingIndex(DataTable _dt)
        {
            BookingIndexViewModel _bookingViewModel = new BookingIndexViewModel();

            foreach (DataRow dr in _dt.Rows)
            {
                _bookingViewModel.RoomId = Int16.Parse(dr["RoomID"].ToString());
                _bookingViewModel.RoomName = dr["RoomName"].ToString();
                _bookingViewModel.RoomImage = dr["RoomImage"].ToString();
                _bookingViewModel.Seat = dr["Seat"].ToString();
                _bookingViewModel.RoomFacilities = dr["FacilitiesName"].ToString();
                _bookingViewModel.RoomAvailableDay = dr["AvailableDay"].ToString();
                _bookingViewModel.RoomAvailableTime = dr["AvailableFrom"].ToString() + " - " + dr["AvailableTo"].ToString();
                _bookingViewModel.RoomFloor = dr["FloorName"].ToString();
                _bookingViewModel.Remark = dr["Remark"].ToString();
            }

            return _bookingViewModel;
        }
    }
}
