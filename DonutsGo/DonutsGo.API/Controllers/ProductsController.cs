using DonutsGo.API.Entities;
using Microsoft.AspNetCore.Components;

namespace DonutsGo.API.Controllers
{
    [Route("[controller]")]
    public class ProductsController
    {
        public ProductsController()
        { }

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id =Guid.NewGuid(),
                    Name="Donut Chocolate",
                    Price =10,
                    Type =ProductType.Donut,


                }
            };
        }
    }
}
