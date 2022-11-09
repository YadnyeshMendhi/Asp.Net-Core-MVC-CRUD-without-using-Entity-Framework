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

        [Required(ErrorMessage ="Please enter Brand name")]
        public string Brand { get; set; }

        [Required(ErrorMessage ="Please enter Model name")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please enter Price ")]
        [Range(1, int.MaxValue, ErrorMessage = "Should be greater than or equal 1")]
        public int Price { get; set; }

        /*
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }*/

        public DateTime DateTime { get; set; }
    }
}
