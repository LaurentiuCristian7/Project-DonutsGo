using DonutsGo.Application.Models.Products;
using DonutsGo.Shared.Models.Products;

namespace DonutsGo.Application.Services;

public interface IProductService
{
    void DeleteProductById(Guid productId);

    ProductResponseModel GetProductById(Guid productId);

    List<ProductResponseModel> GetAllProducts();

    ProductResponseModel CreateProduct(CreateProductRequestModel model);

    ProductResponseModel UpdateProduct(Guid id, UpdateProductRequestModel model);
}

