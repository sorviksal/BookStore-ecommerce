using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class WishlistItem
    {
        [Key]
        public int WishlistItemId { get; set; }

        [Required]
        public int WishlistId { get; set; }

        [Required]
        public int BookId { get; set; }

        [ForeignKey(nameof(WishlistId))]
        public Wishlist Wishlist { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }
    }
}
