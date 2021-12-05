using Buy.IRepository.Interfaces;
using Buy.IService.Interfaces;
using Buy.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Buy.Service
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public Task<List<Product>> GetProducts()
        {
            return _productsRepository.GetProducts();
        }
    }
}
