using AutoMapper;
using Bussiness.Repository.IRepositories;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Repository
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private ApplicationDbContext _db;
        private readonly IMapper _Mapper;
        public HotelRoomRepository(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _Mapper = mapper;
        }

        public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomdto)
        {
            var HotelRoom = _Mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomdto);
            HotelRoom.CreatedDate = DateTime.Now;
            HotelRoom.CreatedBy = "";
            var AddedHotelRoom = await _db.HotelRooms.AddAsync(HotelRoom);
            await _db.SaveChangesAsync();

            return _Mapper.Map<HotelRoom ,HotelRoomDTO>(AddedHotelRoom.Entity);

        }

        public async Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms()
        {
            try
            { 
                var ListOfRoomDTOS = _Mapper.Map<IEnumerable<HotelRoom>, IEnumerable<HotelRoomDTO>>(_db.HotelRooms.Include(a=>a.HotelRoomImages));
                return ListOfRoomDTOS;
            }
            catch (Exception)
            {

               return null;
            }
          

        }

        public async Task<HotelRoomDTO> GetHotelRoom(int RoomId)
        {

            try
            {
                var RoomFromDataBase = await _db.HotelRooms.Include(a=>a.HotelRoomImages).SingleOrDefaultAsync(a => a.Id == RoomId);

                var RoomDTO = _Mapper.Map<HotelRoom, HotelRoomDTO>(RoomFromDataBase);

                return RoomDTO;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public async Task<HotelRoomDTO> IsSameRoomAlreadyPresent(string name , int Id = 0)
        {
            try
            {
                if (Id == 0)
                {              
                var RoomFromDataBase = await _db.HotelRooms.SingleOrDefaultAsync(a => a.Name == name);
                var RoomDTO = _Mapper.Map<HotelRoom, HotelRoomDTO>(RoomFromDataBase);

                return RoomDTO;
                }
                else
                {
                    var RoomFromDataBase = await _db.HotelRooms.SingleOrDefaultAsync(a => a.Name == name && a.Id != Id);
                    var RoomDTO = _Mapper.Map<HotelRoom, HotelRoomDTO>(RoomFromDataBase);

                    return RoomDTO;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<HotelRoomDTO> UpdateHotelRoom(int RoomId, HotelRoomDTO hotelRoomdto)
        {
            try
            {
                var RoomDetails = await _db.HotelRooms.FindAsync(RoomId);

                var Room = _Mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomdto, RoomDetails);
                Room.UpdatedBy = "";
                Room.UpdatedDate = DateTime.Now;

                var UpdatedRoom = _db.HotelRooms.Update(Room);
                await _db.SaveChangesAsync();

                return _Mapper.Map<HotelRoom, HotelRoomDTO>(UpdatedRoom.Entity);
            }
            catch (Exception)
            {

                return null;
            }
          

        }

        public async Task<int> DeleteRoom(int RoomId)
        {
            try
            {
                var DeletedRoom = await _db.HotelRooms.FindAsync(RoomId);

                var ListOfImages = await _db.HotelRoomImages.Where(a => a.RoomId == RoomId).ToListAsync();
               
                _db.RemoveRange(ListOfImages);
                var Delete = _db.HotelRooms.Remove(DeletedRoom);

                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                return 0;
            }
          

        }
    }
}
