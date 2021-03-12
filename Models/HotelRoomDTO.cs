using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class HotelRoomDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter The Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Enter the Occupancy")]
        public int Occupancy { get; set; }  
        [Range(1,3000,ErrorMessage ="Regular Rate Must Be Between 1 And 3000 $")]
        public double RegularRate { get; set; }
        public string Details { get; set; }
        public string SqFt { get; set; }

        public virtual ICollection<HotelRoomImageDTO> HotelRoomImages { get; set; }
        public List<string> ImageUrls { get; set; }

    }
}
