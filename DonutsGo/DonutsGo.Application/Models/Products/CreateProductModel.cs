using DonutsGo.DataAccess.Entities;

namespace DonutsGo.Application.Models.Products
{
    public class CreateProductModel  
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductType Type { get; set; }

    }
}
