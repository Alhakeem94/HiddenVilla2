using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
   public class HotelAmienties
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter a valid Name")]
        [MaxLength(50,ErrorMessage ="The number of Chars Exceds the allowed Number ")]
        public string Name { get; set; }
        [Required]
        public string Timing { get; set; }
        public DateTime Date { get; set; }


    }
}
