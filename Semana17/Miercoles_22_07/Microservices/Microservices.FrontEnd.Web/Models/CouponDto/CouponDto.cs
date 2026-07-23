namespace Microservices.FrontEnd.Web.Models.CouponDto
{
    public class CouponDto
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinimunAmount { get; set; }
    }
}
