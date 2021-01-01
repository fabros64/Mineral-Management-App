using AutoMapper;
using Microsoft.Extensions.Options;
using Mineral_Management.Business.Interfaces;
using Mineral_Management.Business.Models;
using Mineral_Management.Data.Context;
using Mineral_Management.Data.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mineral_Management.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context = null;
        private readonly IMapper mapper;

        public ProductRepository(IOptions<Mineral_Management_ApiDbSettings> settings, IMapper mapper)
        {
             _context = new ProductContext(settings) ?? throw new ArgumentNullException(nameof(settings));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductBusiness>> GetAllProductsAsync()
        {
            try
            {
                var products = await _context.Products.Find(_ => true).ToListAsync();
                var productsBusiness = mapper.Map<IEnumerable<ProductBusiness>>(products);
                return productsBusiness;
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
                if (productId == null)
                {
                    throw new ArgumentNullException(nameof(productId));
                }

                var deletedProduct = await _context.Products
                    .FindOneAndDeleteAsync(p => p.ProductId == productId);

                if (deletedProduct != null)
                    return true;
                else return false;
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
                if (productBusiness == null)
                {
                    throw new ArgumentNullException(nameof(productBusiness));
                }

                var product = mapper.Map<Product>(productBusiness);

                var products = await _context.Products.Find(_ => true).ToListAsync();

                var oldProduct = products.FirstOrDefault(op => op.ProductId == product.ProductId);

                product = oldProduct;
                product.Minerals = mapper.Map<Minerals>(productBusiness.Minerals);
                product.Description = productBusiness.Description;
                product.Name = productBusiness.Name;

                var result = await _context.Products.FindOneAndReplaceAsync(p => p.ProductId == product.ProductId, product);

                if (result != null)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddProductAsync(ProductBusiness productBusiness)
        {
            try
            {
                if (productBusiness == null)
                {
                    throw new ArgumentNullException(nameof(productBusiness));
                }

                var product = mapper.Map<Product>(productBusiness);
                product.products = product.Name != "" ? product.Name : "product";
                await _context.Products.InsertOneAsync(product);

                var insertedProduct = await _context.Products
                           .Find(p => p.ProductId == product.ProductId || p.InternalId == product.InternalId)
                           .Limit(1)
                           .FirstOrDefaultAsync();
                if (insertedProduct != null) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
