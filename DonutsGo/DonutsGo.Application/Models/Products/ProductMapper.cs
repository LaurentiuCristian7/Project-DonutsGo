using DonutsGo.DataAccess.Entities;
using DonutsGo.Shared.Models;
using DonutsGo.Shared.Models;
using DonutsGo.Shared.Models.Products;

namespace DonutsGo.Application.Models.Products;

public static class ProductMapper
{
     public  static ProductResponseModel FromProduct(Product product)
     {
        return new ProductResponseModel
        {
           Id = product.Id,
           Name = product.Name,
           Price = product.Price,
           Type = (ProductTypeResponseModel)product.Type
        };
     }
}

