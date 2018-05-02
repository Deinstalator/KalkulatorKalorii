using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalkulatorKalorii.Models;
using KalkulatorKalorii.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalkulatorKalorii.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IMacronutrientRepository _macronutrientRepository;

        public ProductController(IProductRepository productRepository, IProductTypeRepository productTypeRepository, IMacronutrientRepository macronutrientRepository)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _macronutrientRepository = macronutrientRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetProducts()
        {
            return new JsonResult(_productRepository.GetAllProducts());
        }

        [HttpPost("[action]")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productType = _productTypeRepository.GetProductType(product.ProductTypeId);
            if(productType == null)
            {
                return NotFound("Cannot find product type with provided productTypeId.");
            }

            var macronutrient = _macronutrientRepository.GetMacronutrient(product.MacronutrientId);
            if(macronutrient == null)
            {
                return NotFound("Cannot find macronutrient with provided macronutrientId.");
            }

            _productRepository.AddProduct(product, productType, macronutrient);

            return new JsonResult(product.Id);
        }

        [HttpGet("[action]")]
        public IActionResult GetProduct(int productId)
        {
            if(productId <= 0)
            {
                return BadRequest("Id cannot be less tans 0.");
            }

            return new JsonResult(_productRepository.GetProduct(productId));
        }

        [HttpPost("[action]")]
        public IActionResult UpdateProduct([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productRepository.UpdateProduct(product);

            return new JsonResult(product.Id);
        }

        [HttpGet("[action]")]
        public IActionResult DeleteProduct(int productId)
        {
            if(productId <= 0)
            {
                return BadRequest("Id cannot be less than 0.");
            }

            var product = _productRepository.GetProduct(productId);
            if(product == null)
            {
                return NotFound("Cannot find product with provided productId.");
            }

            var productType = _productTypeRepository.GetProductType(product.ProductTypeId);
            if (productType == null)
            {
                return NotFound("Cannot find product type with provided productTypeId.");
            }

            var macronutrient = _macronutrientRepository.GetMacronutrient(product.MacronutrientId);
            if (macronutrient == null)
            {
                return NotFound("Cannot find macronutrient with provided macronutrientId.");
            }

            _productRepository.DeleteProduct(product, productType, macronutrient);
            return new JsonResult(product.Id);
        }
    }
}