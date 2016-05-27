using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.DataAccess;
using System.Linq;

namespace Demo.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private ProductContext context;

        // Dependency injection
        public HomeController(ProductContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            TodoItemIndexModel model = GetTodoItems();
            return this.View(model);
        }

        [HttpGet]
        public TodoItemIndexModel GetTodoItems()
        {
            TodoItemIndexModel model = new TodoItemIndexModel();
            model.TemplateItem = new TodoItem();
            model.TodoItems = this.context.TodoItems.ToList();
            model.DropdownCategories = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            foreach (String s in context.Categories)
                model.DropdownCategories.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = s,
                    Value = s
                });
            return model;
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            TodoItemIndexModel model = new TodoItemIndexModel();
            model.TemplateItem = new TodoItem();
            model.DropdownCategories = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            foreach (String s in this.context.Categories)
                model.DropdownCategories.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text = s,
                    Value = s
                });
            return this.View(model);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(TodoItemIndexModel item)
        {
            if (ModelState.IsValid)
            {
                this.context.TodoItems.Add(item.TemplateItem);
                return RedirectToAction("Index");
            }
            else
            {
                item.DropdownCategories = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
                foreach (String s in this.context.Categories)
                    item.DropdownCategories.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                    {
                        Text = s,
                        Value = s
                    });
                return this.View(item);
            }
        }
    }
}
