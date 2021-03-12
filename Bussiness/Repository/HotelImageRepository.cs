using AutoMapper;
using Bussiness.Repository.IRepositories;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Repository
{
    public class HotelImageRepository : IHotelImagesRepository
    {
        private ApplicationDbContext _db;
        private readonly IMapper _Mapper;
        public HotelImageRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _Mapper = mapper;
        }

        public async Task<int> CreateHotelRoomImage(HotelRoomImageDTO imageDTO)
        {

            var image = _Mapper.Map<HotelRoomImageDTO, HotelRoomImage>(imageDTO);
            await _db.HotelRoomImages.AddAsync(image);
            return await _db.SaveChangesAsync();


        }

        public async Task<int> DeleteHotelRoomImageByImageId(int ImageId)
        {
            var image = await _db.HotelRoomImages.FindAsync(ImageId);
             _db.HotelRoomImages.Remove(image);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteHotelRoomImageByRoomId(int RoomId)
        {
            var imageList = await _db.HotelRoomImages.Where(a => a.RoomId == RoomId).ToListAsync();
            _db.HotelRoomImages.RemoveRange(imageList);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelRoomImageDTO>> GetHotelRoomImages(int RoomId)
        {
            var ImageList = await _db.HotelRoomImages.Where(a => a.RoomId == RoomId).ToListAsync();

            return _Mapper.Map<IEnumerable<HotelRoomImage>, IEnumerable<HotelRoomImageDTO>>(ImageList);
        }

        public async Task<int> DeletehotelImageByUrl(string imageUrl)
        {
            var allImages = await _db.HotelRoomImages.FirstOrDefaultAsync(a => a.RoomImageUrl.ToLower() == imageUrl.ToLower());
            if (allImages == null)
            {
                return 0;
            }
            _db.HotelRoomImages.Remove(allImages);
            return await _db.SaveChangesAsync();
        }
    }
}
