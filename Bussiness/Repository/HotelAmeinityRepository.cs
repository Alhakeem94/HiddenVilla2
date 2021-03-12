using AutoMapper;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Repository.IRepositories
{
    public class HotelAmeinityRepository : IAmeinityRepository
    {
        private ApplicationDbContext _db;
        private IMapper _Mapper;

        public HotelAmeinityRepository(ApplicationDbContext Db , IMapper mapper)
        {
            _db = Db;
            _Mapper = mapper;
        }

        public async Task<int> CreateHotelAmeinity(HotelAmeinityDTO hotelAmeinityDTO)
        {
        
                var HotelAmeinity = _Mapper.Map<HotelAmeinityDTO, HotelAmienties>(hotelAmeinityDTO);
                HotelAmeinity.Date = DateTime.Now;
                await _db.Amienties.AddAsync(HotelAmeinity);
                return await _db.SaveChangesAsync();
           
        }

        public async Task<int> DeleteHotelAmeinity(int Id)
        {
             var DeletedAmienity =await _db.Amienties.FindAsync(Id);
             _db.Amienties.Remove(DeletedAmienity);
             return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<HotelAmeinityDTO>> GetAllAmeinities()
        {
            return _Mapper.Map<IEnumerable<HotelAmienties>, IEnumerable<HotelAmeinityDTO>>( _db.Amienties);
        }

        public async Task<HotelAmeinityDTO> GetHotelAmeinity(int Id)
        {
            var HotelAmeinity = await _db.Amienties.FindAsync(Id);
            var AmeinityDto =  _Mapper.Map<HotelAmienties, HotelAmeinityDTO>(HotelAmeinity);
            return AmeinityDto;
        }

        public async Task<bool> IsAmeinityUnique(string Name)
        {
            var Ameinity = _db.Amienties.Where(a => a.Name == Name).Count();
            if (Ameinity != 0)
            {
                return false;
            }

            return true;
        }

        public async Task<int> UpdateHotelAmeinity(int Id, HotelAmeinityDTO hotelAmeinityDTO)
        {
            try
            {
                var Ameinity = await _db.Amienties.FindAsync(Id);
                var AmienotyDtoFromDatabase = _Mapper.Map<HotelAmienties, HotelAmeinityDTO>(Ameinity);

                AmienotyDtoFromDatabase = hotelAmeinityDTO;

                _db.Amienties.Update(_Mapper.Map<HotelAmeinityDTO, HotelAmienties>(AmienotyDtoFromDatabase));

                return await _db.SaveChangesAsync();
            }
            catch (Exception)
            {

                return 0;
            }


        }
    }
}
