using DonutsGo.Application.Exceptions;
using DonutsGo.Application.Models.Products;
using DonutsGo.Application.Services;
using DonutsGo.DataAccess;
using DonutsGo.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using DonutsGo.Application.Exceptions;


namespace DonutsGo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    { 
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        { 
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var  product =Products.FirstOrDefault(x => x.Id == id);

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct( CreateProductRequestModel requestModel)
        {
            try
            {
                return Ok( this.productService.CreateProduct(requestModel));
            }
            catch(ValidationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id}")]
        public  IActionResult UpdateProduct(Guid id, Product newProduct)
        {
            var product = Storage.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound("");
            }

            product.Name=newProduct.Name;
            product.Price=newProduct.Price;
            product.Type = newProduct.Type;

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            
           this.productService.DeleteProductById(id);

            return NoContent();
        }
    }
}
