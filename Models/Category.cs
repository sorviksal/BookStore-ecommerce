using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace E_Commerce.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, MaxLength(100)]
        public string CategoryName { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string Image {  get; set; }
        public bool Status { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
