using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Wishlist
    {
        [Key]
        public int WishlistId { get; set; }

        [Required]
        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
    }
}
