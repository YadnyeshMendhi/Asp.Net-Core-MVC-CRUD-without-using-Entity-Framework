using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDwithoutEF.Models
{
    public class PhoneViewModel
    {
        [Key]
        public int PhoneID { get; set; }
        [Required]
        public string Brand  { get; set; }
        [Required]
        public string Model { get; set; }
        [Range(1,int.MaxValue, ErrorMessage ="Should be greater than or equal 1")]
        public int Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
}
