using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models
{
    public class Coupon
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Display(Name = "Coupon Type")]
        [Required]
        public string CouponType { get; set; }

        public enum ECouponType { Percent = 0, Dollar = 1 }

        [Required]
        public double Discount { get; set; }
        
        [Required]
        [Display(Name = "Minimum Amount")]
        public double MinimumAmount { get; set; }

        public Byte[] Picture { get; set; }

        [Display(Name = "Is Active")]
        public bool isActive { get; set; }

        public DateTime ExperationDate { get; set; }

    }
}
