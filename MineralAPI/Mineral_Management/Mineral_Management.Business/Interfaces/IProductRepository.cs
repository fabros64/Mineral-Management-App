using Mineral_Management.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mineral_Management.Business.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> AddProductAsync(ProductBusiness productBusiness);
        Task<IEnumerable<ProductBusiness>> GetAllProductsAsync();
        Task<bool> DeleteProductAsync(string productId);
        Task<bool> UpdateProductAsync(ProductBusiness productBusiness);
    }
}
