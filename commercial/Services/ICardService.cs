using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using commercial.Models;
using dbProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace commercial.Services
{
    public interface ICardService
    {
        public IActionResult RemoveProduct(UpdateCardRequest updateRequest);
        public IActionResult AddProduct(UpdateCardRequest updateRequest);
        public List<Product> GetProducts(int userId);
    }
}