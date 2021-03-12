using DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Repository.IRepositories
{
   public interface IHotelRoomRepository
    {
        public Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomdto);
        public Task<HotelRoomDTO> UpdateHotelRoom(int RoomId,HotelRoomDTO hotelRoomdto);
        public Task<HotelRoomDTO> GetHotelRoom(int RoomId);
        public Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms();
        public Task<HotelRoomDTO> IsSameRoomAlreadyPresent(string name , int Id = 0);
        public Task<int> DeleteRoom(int RoomId);


    }
}
