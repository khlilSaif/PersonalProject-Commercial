using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dbProject.Models;

namespace commercial.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
    }
}