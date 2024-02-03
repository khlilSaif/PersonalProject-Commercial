using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dbProject.Models;

namespace commercial.RepositoryPattern
{
    public class ProductRepository : IRepositoryPattern<Product>
    {
        public readonly DatabaseContext _dbContext;   
        public ProductRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product? GetById(int productId){
           return _dbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
        public IEnumerable<Product> GetAll(){
            return _dbContext.Products.ToList();
        }
        public void Add(Product product){
            _dbContext.Products.Add(product);
        }
        public void Update(Product product){
            _dbContext.Products.Update(product);
        }
        public void Delete(Product product){
            _dbContext.Products.Remove(product);
        }
    }
}