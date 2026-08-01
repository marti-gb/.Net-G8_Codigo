using System.ComponentModel.DataAnnotations;

namespace Microservices.BackEnd.CouponAPI.Models.Dto
{
    public class CouponDto
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinimunAmount { get; set; }
    }
}
