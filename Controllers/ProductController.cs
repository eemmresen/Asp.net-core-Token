using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Domain.Services;
using AutoMapper;
using WebApplication2.Domain.Responses;
using WebApplication2.Resources;
using WebApplication2.Extensions;
using WebApplication2.Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericService<Product> productService;
        private readonly IMapper mapper;

        public ProductController(IGenericService<Product> productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;


        }
        [HttpGet]
        public async Task<IActionResult> Getlist() 
        {
            BaseResponse<IEnumerable<Product>> productListResponse = await productService.GetWhere(x => x.Id > 0);

            if (productListResponse.Success)
            {
                return Ok(productListResponse.Extra);
            }
            else
            {
                return BadRequest(productListResponse.ErrorMessage);            }
          
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFindById(int id)
        {
            BaseResponse<Product> productResponse = await productService.GetById(id);
            if (productResponse.Success)
            {
                return Ok(productResponse.Extra);
            }
            else
            {
                return BadRequest(productResponse.ErrorMessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductResource productResource)
        {
            if (!ModelState.IsValid)
            {
               
                return BadRequest( ModelState.GetErrorMessages());
            }
            else
            {
                Product product = mapper.Map<ProductResource, Product>(productResource);
                var Response = await productService.Add(product);
                if (Response.Success)
                {
                    return Ok(Response.Extra);
                }
                else
                {
                    return BadRequest(Response.ErrorMessage);
                }

            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductResource productResource, int id) 
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                Product product = mapper.Map<ProductResource, Product>(productResource);
                product.Id = id;

                var response = await productService.update(product);
                if (response.Success)
                {
                    return Ok(response.Extra);
                }
                else
                {
                    return BadRequest(response.ErrorMessage);
                }

            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveProduct(int productId)
        {
            BaseResponse<Product> response = await productService.Delete(productId);
                if (response.Success)
                {
                    return Ok(response.Extra);
                }
                else
                {
                    return BadRequest(response.ErrorMessage);
                }

        }

    }
}