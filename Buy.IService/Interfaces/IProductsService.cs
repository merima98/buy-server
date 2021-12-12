using Buy.IRepository.Interfaces;
using Buy.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Buy.IService.Interfaces
{
    public interface IProductsService
    {
        /// <summary>
        /// Returns list of products.
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetProducts();

        /// <summary>
        /// Returns single product filtered per ID.
        /// </summary>
        /// <returns></returns>
        Product GetProductById(Guid productId);
    }
}
