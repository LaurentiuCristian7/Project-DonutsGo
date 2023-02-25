using DonutsGo.API.Entities;

namespace DonutsGo.API.Models.Products
{
    public class ProductResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductType Type { get; set; }
    }
}
