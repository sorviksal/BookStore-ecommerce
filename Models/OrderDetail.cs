using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        public int? OrderId { get; set; }

        public int? BookId { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? UnitPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Discount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Subtotal { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
    }
}
