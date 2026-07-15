using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        [Required, MaxLength(200)]
        public string PublisherName { get; set;}
        [MaxLength(30)]
        public string Phone { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(200)]
        public string Website {  get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
