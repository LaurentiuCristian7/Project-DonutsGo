using DonutsGo.Application.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutsGo.Application.Services
{
    public class ProductService2 : IProductService
    {
        public List<ProductResponseModel> GetAllProducts()
        {
            return new List<ProductResponseModel>
            {
                new ProductResponseModel
                {
                    Id = Guid.NewGuid()
                }
            };
        }

        public ProductResponseModel CreateProduct(CreateProductModel model)
        {
            throw new NotImplementedException();
        }

        public ProductResponseModel UpdateProduct(Guid id, UpdateProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
