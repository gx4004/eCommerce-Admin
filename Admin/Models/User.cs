using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}