using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public int? OrderId { get; set; }

        public int? PaymentMethodId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }

        [MaxLength(100)]
        public string TransactionReference { get; set; }

        [MaxLength(255)]
        public string QRCode { get; set; }

        public DateTime? PaidDate { get; set; }

        [MaxLength(30)]
        public string Status { get; set; }

        public int? VerifiedBy { get; set; }

        [MaxLength(255)]
        public string Remark { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [ForeignKey(nameof(PaymentMethodId))]
        public PaymentMethod PaymentMethod { get; set; }
    }
}
