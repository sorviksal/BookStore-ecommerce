using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class OrderCoupon
    {

        [Key]
        public int OrderCouponId { get; set; }

        public int? OrderId { get; set; }

        public int? CouponId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscountAmount { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [ForeignKey(nameof(CouponId))]
        public Coupon Coupon { get; set; }
    }
}
