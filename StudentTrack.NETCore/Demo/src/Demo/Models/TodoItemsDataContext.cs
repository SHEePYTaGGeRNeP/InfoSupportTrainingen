using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Demo.Models
{
    public class TodoItemsDataContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        //public TodoItemsDataContext() : base("name=TodoItemsDataContext")
        //{
        //    Database.SetInitializer<TodoItemsDataContext>(null);
        //}

        public DbSet<Demo.Models.TodoItem> TodoItems { get; set; }
        public static List<TodoItem> TestItems { get; set; } = new List<TodoItem>()
        {
            new TodoItem() {Category = "Activiteiten", Id = 1, Name = "Hardlopen"},
            new TodoItem() {Category = "Moeders", Id = 2, Name = "Je moeder"},
        };

        public static string[] Categories
        {
            get
            {
                HashSet<string> categories = new HashSet<string>();
                foreach (string s in TestItems.Select ( x => x.Category))
                    categories.Add(s);
                return categories.ToArray();
            }
        }
    }
}
