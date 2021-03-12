using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Repository.IRepositories
{
   public interface IHotelImagesRepository
    {
        public Task<int> CreateHotelRoomImage(HotelRoomImageDTO image);
        public Task<int> DeleteHotelRoomImageByImageId(int ImageId);
        public Task<int> DeleteHotelRoomImageByRoomId(int RoomId);
        public Task<IEnumerable<HotelRoomImageDTO>> GetHotelRoomImages(int RoomId);
        public Task<int> DeletehotelImageByUrl(string imageUrl);

    }
}
