using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Demo.DataAccess
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductModel> Producten { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        public string[] Categories
        {
            get
            {
                HashSet<string> categories = new HashSet<string>();
                List<TodoItem> todos = TodoItems.ToList();
                foreach (string s in todos.Select(x => x.Category))
                    categories.Add(s);
                return categories.ToArray();
            }
        }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }


    }
}
