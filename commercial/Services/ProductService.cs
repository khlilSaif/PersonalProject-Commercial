using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using commercial.RepositoryPattern;
using dbProject.Models;

namespace commercial.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryPattern<Product> _productRepository;
        public ProductService(IRepositoryPattern<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public List<Product> GetAllProducts(){
            return _productRepository.GetAll().ToList();
        }
    }
}