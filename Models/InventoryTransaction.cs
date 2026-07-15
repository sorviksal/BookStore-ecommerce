using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class InventoryTransaction
    {
        [Key]
        public int InventoryId { get; set; }

        public int? BookId { get; set; }

        [MaxLength(20)]
        public string TransactionType { get; set; }

        public int? Quantity { get; set; }

        [MaxLength(100)]
        public string Reference { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
    }
}
