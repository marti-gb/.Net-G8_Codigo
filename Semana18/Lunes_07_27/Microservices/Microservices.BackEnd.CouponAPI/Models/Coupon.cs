using System.ComponentModel.DataAnnotations;

namespace Microservices.BackEnd.CouponAPI.Models
{
    public class Coupon
    {
        public int Id { get; set; }

        [Required]
        public string CouponCode { get; set; }

        [Required]
        public double DiscountAmount { get; set; }
        public int MinimunAmount { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
