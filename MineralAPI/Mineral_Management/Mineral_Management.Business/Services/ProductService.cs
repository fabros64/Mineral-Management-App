using Mineral_Management.Business.Interfaces;
using Mineral_Management.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mineral_Management.Business.Services
{
    public class ProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository
                 ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> AddProductAsync(ProductBusiness productBusiness)
        {
            try
            {
                return await repository.AddProductAsync(productBusiness);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProductBusiness>> GetAllProductsAsync()
        {
            try
            {
                return await repository.GetAllProductsAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> DeleteProductAsync(string productId)
        {
            try
            {
                return await repository.DeleteProductAsync(productId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> UpdateProductAsync(ProductBusiness productBusiness)
        {
            try
            {
                return await repository.UpdateProductAsync(productBusiness);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
