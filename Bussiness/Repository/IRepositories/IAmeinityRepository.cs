using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Repository.IRepositories
{
   public interface IAmeinityRepository
    {
        public Task<HotelAmeinityDTO> GetHotelAmeinity(int Id);
        public Task<int> CreateHotelAmeinity(HotelAmeinityDTO hotelAmeinityDTO);
        public Task<int> UpdateHotelAmeinity(int Id,HotelAmeinityDTO hotelAmeinityDTO);
        public Task<IEnumerable<HotelAmeinityDTO>> GetAllAmeinities();
        public Task<bool> IsAmeinityUnique(string Name);
        public Task<int> DeleteHotelAmeinity(int Id);

    }
}
