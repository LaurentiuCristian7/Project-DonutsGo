using DonutsGo.DataAccess.Entities;

namespace DonutsGo.Application.Models.Products
{
    public class ProductResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductType Type { get; set; }

        public static ProductResponseModel FromProduct(Product product)
        {
            return new ProductResponseModel
            {
                Id =product.Id,
                Name = product.Name,
                Price=product.Price,
                Type=product.Type
            };
        }
    }
}
