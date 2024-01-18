using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using commercial.Models;
using commercial.Services;
using dbProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace commercial.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase 
    {
        private readonly ICardService _cartService;

        public CartController(ICardService cartService){
            _cartService = cartService;
        }
 
        [HttpGet("getProducts")]
        public List<Product> GetProducts(int userId){
            return _cartService.GetProducts(userId); 
        }

        [HttpPost("addProduct")]
        public IActionResult AddProduct(UpdateCardRequest updateRequest){
            return _cartService.AddProduct(updateRequest);
        }

        [HttpDelete("RemoveProduct")]
        public IActionResult RemoveProduct(UpdateCardRequest updateRequest){
            return _cartService.RemoveProduct(updateRequest);
        }

    }
}