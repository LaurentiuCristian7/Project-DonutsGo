using DonutsGo.API.Entities;
using DonutsGo.API.Models.Products;
using Microsoft.AspNetCore.Mvc;


namespace DonutsGo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController() 
        { }

        [HttpGet]
        public IActionResult GetProducts()
        {
            // return new List<Product>
            // {
            //     new Product
            //     {
            //         Id =Guid.NewGuid(),
            //         Name="Donut Chocolate",
            //         Price =10,
            //         Type =ProductType.Donut,
            //
            //
            //     }
            // };
            var products = Storage.Products.Select(x => new ProductResponseModel
            {
                Id= x.Id,
                Name= x.Name, 
                Price = x.Price,
                Type = x.Type
            });
            return  Ok(products);
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
            var product = new Product
            {
                Id =Guid.NewGuid(),
                Name = requestModel.Name,
                Price = requestModel.Price,
                Type = requestModel.Type,
            };

            if(string.IsNullOrEmpty(requestModel.Name))
            {
                return BadRequest("Name cannot be empty");

            }

            if (requestModel.Name.Length < 4)
            {
                return BadRequest("Name should  have lenght greater than 4.");
            }

            Storage.Products.Add(product);

            return Ok(product);
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
