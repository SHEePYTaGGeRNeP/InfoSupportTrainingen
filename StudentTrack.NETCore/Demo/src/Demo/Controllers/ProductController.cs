using System;
using System.Collections.Generic;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Demo.DataAccess;
using System.Linq;

namespace Demo.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private ProductContext _context;
        // Dependency injection
        public ProductController(ProductContext context)
        {
            this._context = context;
        }


        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return this._context.Producten.ToList();
            //throw new NotImplementedException("Jammer joh");
            //return new List<ProductModel>()
            //{
            //    new ProductModel() { Id = 1, Product = "iPhone", Price = 600},
            //    new ProductModel() { Id = 2, Product =  "Lenovo Laptop", Price = 700},
            //    new ProductModel() { Id = 3, Product =  "Je moeder", Price = 0.50}
            //};
        }
    }
}
