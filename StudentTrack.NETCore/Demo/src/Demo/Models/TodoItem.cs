using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDone { get; set; }
        [Required]
        public string Category { get; set; }

    }


}
