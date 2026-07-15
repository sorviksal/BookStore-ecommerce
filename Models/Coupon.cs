using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }

        [MaxLength(20)]
        public string DiscountType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscountValue { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MinimumOrder { get; set; }

        public DateTime? ExpireDate { get; set; }

        public bool Status { get; set; } = true;

        public ICollection<OrderCoupon> OrderCoupons { get; set; } = new List<OrderCoupon>();
    }
}
