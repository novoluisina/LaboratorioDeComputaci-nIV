using System.ComponentModel.DataAnnotations;

namespace todo_item.Models
{
    public class UserPostDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public string UserType { get; set; }

    }
}

