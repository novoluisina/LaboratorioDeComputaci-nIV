using System.ComponentModel.DataAnnotations;

namespace todo_item.Models
{
    public class Itemdto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}