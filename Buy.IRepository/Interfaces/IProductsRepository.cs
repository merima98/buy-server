using Buy.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buy.IRepository.Interfaces
{
    public interface IProductsRepository
    {
        /// <summary>
        /// Returns list of products.
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetProducts();

        Product GetProductById(Guid productId);
    }
}
