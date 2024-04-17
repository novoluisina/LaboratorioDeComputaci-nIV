using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace todo_item.Entities
{
    public class Todo_item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_item { get; set; }
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; } // Clave foránea
        public User User { get; set; }

    }
}
