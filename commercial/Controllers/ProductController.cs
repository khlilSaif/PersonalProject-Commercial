using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using commercial.Services;
using dbProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace commercial.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getallproducts")]
        public List<Product> GetAllProducts(){
            return _productService.GetAllProducts();
        }
    }
}