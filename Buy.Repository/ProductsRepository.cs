using Buy.IRepository.Interfaces;
using Buy.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buy.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        protected buyPlatformContext _buyPlatformContext;
        public ProductsRepository(buyPlatformContext buyPlatformContext)
        {
            _buyPlatformContext = buyPlatformContext;
        }

        public Task<List<Product>> GetProducts()
        {
            return Task.FromResult(_buyPlatformContext.Products.ToList());
        }
    }
}
