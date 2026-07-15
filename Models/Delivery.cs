using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }

        public int? OrderId { get; set; }

        public int? ShippingMethodId { get; set; }

        [MaxLength(100)]
        public string TrackingNumber { get; set; }

        public DateTime? ShippingDate { get; set; }

        public DateTime? DeliveredDate { get; set; }

        [MaxLength(255)]
        public string CurrentLocation { get; set; }

        [MaxLength(30)]
        public string Status { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [ForeignKey(nameof(ShippingMethodId))]
        public ShippingMethod ShippingMethod { get; set; }
    }
}
