using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalkulatorKalorii.Models;
using KalkulatorKalorii.Models.Interfaces;
using KalkulatorKalorii.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalkulatorKalorii.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductTypes")]
    public class ProductTypesController : Controller
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypesController(IProductTypeRepository productRepository)
        {
            _productTypeRepository = productRepository;
        }

        [HttpPost("[action]")]
        public IActionResult AddProductType([FromBody] ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _productTypeRepository.AddProductType(productType);

            return new JsonResult(productType.ProductTypeId);
        }
    }
}