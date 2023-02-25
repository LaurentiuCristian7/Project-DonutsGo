using DonutsGo.API.Entities;
using Microsoft.AspNetCore.Mvc;


namespace DonutsGo.API.Controllers
{
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        { }

        [HttpGet]
        public  List<Product> GetProducts()
        {
          // return new List<Product>
          //  {
         //     new Product
          //      {
          //          Id = Guid.NewGuid(),
          //          Name ="Donut Chocolate",
          //          Price = 10,
          //          Type = ProductType.Donut
          //      }
          //  };

            return Storage.Products;
            
        }
        [HttpGet("{id}")]
        public  IActionResult GetProductById(Guid id)
        {
            var  product = Storage.Products.FirstOrDefault(x => x.Id==id);

            return Ok(product);
        }


        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            Storage.Products.Add(product);
            return Ok(product);        
        }

        [HttpPut("{id}")]

        public IActionResult UpdateProduct( Guid id, [FromBody] Product newProduct)
        {
            var product = Storage.Products.FirstOrDefault(x => x.Id==id);

            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            product.Type = newProduct.Type;

            return Ok(product); 
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteProduct(Guid id)
        {
            var product = Storage.Products.FirstOrDefault(x => x.Id==id);

            Storage.Products.Remove(product);

            return NoContent();
        }
    }


}
