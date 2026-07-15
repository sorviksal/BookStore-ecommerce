using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [MaxLength(150)]
        public string FullName { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
