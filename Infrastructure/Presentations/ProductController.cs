using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using Shared.ErrorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentations
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager ServiceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductResultDTO>>> GetAllProducts([FromQuery]ProductSpesificationParameters parameters)
        {
            var products = await ServiceManager.ProductService.GetAllProductsAsync(parameters);
            return Ok(products);
        }
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDTO>>> GetAllBrands()
        {
            var brands = await ServiceManager.ProductService.GetAllBrandsAsync();
            return Ok(brands);
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeResultDTO>>> GetAllTypes()
        {
            var types = await ServiceManager.ProductService.GetAlTypesAsync();
            return Ok(types);
        }
        [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ValidationErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProductResultDTO), (int)HttpStatusCode.OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResultDTO>> GetProduct(int id)
        {
            var product = await ServiceManager.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }
    }
}
