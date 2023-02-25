using DonutsGo.Application.Exceptions;
using DonutsGo.Application.Models.Products;
using DonutsGo.Application.Services;
using DonutsGo.DataAccess;
using DonutsGo.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;


namespace DonutsGo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductsController() 
        { 
            this.productService = new ProductService();
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
          
            return Ok(this.productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var  product = Storage.Products.FirstOrDefault(x => x.Id == id);

            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct( CreateProductModel requestModel)
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
        public  IActionResult UpdateProduct(Guid id, Product newproduct)
        {
            var product = Storage.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name=newproduct.Name;
            product.Price=newproduct.Price;
            product.Type = newproduct.Type;

            return Ok(product);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = Storage.Products.FirstOrDefault(x => x.Id == id);
            
            Storage.Products.Remove(product);

            return NoContent();
        }
    }
}
