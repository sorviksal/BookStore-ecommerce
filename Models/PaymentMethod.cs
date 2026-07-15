using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }

        [MaxLength(100)]
        public string MethodName { get; set; }

        [MaxLength(50)]
        public string Type { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public bool Status { get; set; } = true;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
