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

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            Storage.Products.Add(product);
            return Ok(product);        
        }
    }


}
