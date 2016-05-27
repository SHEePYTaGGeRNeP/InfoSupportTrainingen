using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class TodoItemIndexModel
    {
        [Required]
        public TodoItem TemplateItem { get; set; }
        public List<TodoItem> TodoItems { get; set; }
        public List<SelectListItem> DropdownCategories { get; set; }
    }
}
