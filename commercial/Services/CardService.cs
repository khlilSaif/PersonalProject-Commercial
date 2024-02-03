using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using commercial.Models;
using commercial.RepositoryPattern;
using dbProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace commercial.Services
{
    public class CardService : ICardService
    {
        private readonly IRepositoryPattern<Panel> _panelRepository;
        private readonly IRepositoryPattern<Product> _productRepository;

        public CardService(IRepositoryPattern<Panel> panelRepository, IRepositoryPattern<Product> productRepository)
        {
            _panelRepository = panelRepository;
            _productRepository = productRepository;
        }
        public IActionResult RemoveProduct(UpdateCardRequest updateRequest){
            var product = _productRepository.GetById(updateRequest.ProductId);
            if( product == null ){
                return new OkObjectResult(new {Message = "no product"});
            }

            var panel = _panelRepository.GetById(updateRequest.UserId);
            if( panel == null ){
                return new OkObjectResult(new {Message = "no panel"});
            } 

            if( panel.ProductIds?.FirstOrDefault(product => product == updateRequest.ProductId) == null){
                return new OkObjectResult(new {Message = "no products exist in this panel"});
            }
            
            panel.ProductIds.Remove(updateRequest.ProductId);
            return new OkObjectResult(new {Message = "Success"});
        }
        public IActionResult AddProduct(UpdateCardRequest updateRequest){
            var product = _productRepository.GetById(updateRequest.ProductId);
            if( product == null ){
                return new OkObjectResult(new {Message = "no product"});
            }

            var panel = _panelRepository.GetById(updateRequest.UserId);
            if( panel == null ){
                return new OkObjectResult(new {Message = "no panel"});
            } 

            panel.ProductIds.Add(updateRequest.ProductId);
            return new OkObjectResult(new {Message = "Success"});
        }
        public List<Product> GetProducts(int userId){

            var userProductIds = _panelRepository.GetAll().Where(panel => (panel.UserId == userId)).FirstOrDefault()?.ProductIds;
            List<Product> result = new List<Product>();

            if( userProductIds == null ) {
                return result; 
            }
            
            foreach(int id in userProductIds){
                result.Add(_productRepository.GetById(id));
            }

            return result;
        }
    }
}