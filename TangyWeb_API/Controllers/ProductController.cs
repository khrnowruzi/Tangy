﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tangy_Business.Repository.IRepository;
using Tangy_Models;

namespace TangyWeb_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productRepository.GetAll());
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int? productId)
        {
            if (productId == null || productId <= 0)
            {
                return BadRequest(new ErrorModelDTO
                {
                    ErrorMessage = "Invalid Id!",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var product = await _productRepository.Get(productId.Value);

            if (product == null)
            {
                return BadRequest(new ErrorModelDTO
                {
                    ErrorMessage = "Product not found!",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            return Ok(product);
        }
    }
}
