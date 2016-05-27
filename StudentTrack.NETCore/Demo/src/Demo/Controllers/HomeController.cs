using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;

namespace Demo.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            TodoItemIndexModel model = new TodoItemIndexModel();
            model.TemplateItem = new TodoItem();
            model.TodoItems = TodoItemsDataContext.TestItems;
            return this.View(model);
        }

        [HttpGet]
        public TodoItemIndexModel GetTodoItems()
        {
            TodoItemIndexModel model = new TodoItemIndexModel();
            model.TemplateItem = new TodoItem();
            model.TodoItems = TodoItemsDataContext.TestItems;
            model.DropdownCategories = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            foreach (String s in TodoItemsDataContext.Categories)
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
            foreach (String s in TodoItemsDataContext.Categories)
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
                TodoItemsDataContext.TestItems.Add(item.TemplateItem);
                return RedirectToAction("Index");
            }
            else
                return this.View();
        }
    }
}
