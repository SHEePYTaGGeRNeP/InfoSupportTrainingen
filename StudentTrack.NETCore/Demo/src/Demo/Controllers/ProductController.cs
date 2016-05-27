using System;
using System.Collections.Generic;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            throw new NotImplementedException("Jammer joh");
            return new List<ProductModel>()
            {
                new ProductModel() { Id = 1, Product = "iPhone", Price = 600},
                new ProductModel() { Id = 2, Product =  "Lenovo Laptop", Price = 700}
            };
        }
    }
}
