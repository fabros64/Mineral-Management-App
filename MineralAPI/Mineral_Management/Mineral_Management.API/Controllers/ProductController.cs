using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mineral_Management.API.Models;
using Mineral_Management.Business.Models;
using Mineral_Management.Business.Services;

namespace Mineral_Management.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
      

        private readonly ILogger<ProductController> _logger;
        private readonly ProductService productService;
        private readonly IMapper mapper;

        public ProductController(ILogger<ProductController> logger, ProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
            _logger = logger;
        }

        [Route("/")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<ProductBusiness> products = null;
            try
            {
                 products = await productService.GetAllProductsAsync();
            }
            catch (Exception)
            {
               //logg 
            }
            if (products != null)
                return Ok(products);
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductParam productParam)
        {
            bool isProductParamInserted = false;
            try
            {
                ProductBusiness productBusiness = new ProductBusiness();
                if (productParam != null)
                {
                    productBusiness = mapper.Map<ProductBusiness>(productParam);

                    isProductParamInserted = await productService.AddProductAsync(productBusiness);
                }
                if (isProductParamInserted == true)
                    return Ok();
                else return StatusCode(400);


            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProductAsync(string productId)
        {
            bool isProductDeleted = false;

            try
            {
                if (productId != null)
                {
                    isProductDeleted = await productService.DeleteProductAsync(productId);
                }
                if (isProductDeleted == true)
                    return Ok();
                else return StatusCode(400);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{productParam.ProductId}")]
        public async Task<IActionResult> UpdateItemAsync(ProductParam productParam)
        {
            bool isProductParamUpdated = false;
            try
            {
                ProductBusiness productBusiness = new ProductBusiness();
                if (productParam != null)
                {
                    productBusiness = mapper.Map<ProductBusiness>(productParam);

                    isProductParamUpdated = await productService.UpdateProductAsync(productBusiness);
                }
                if (isProductParamUpdated == true)
                    return Ok();
                else return StatusCode(400);


            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }


    }
}
