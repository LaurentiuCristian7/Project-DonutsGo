using DonutsGo.Application.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutsGo.Application.Services
{
    public interface IProductService
    {
        public List<ProductResponseModel> GetAllProducts();

        public ProductResponseModel CreateProduct(CreateProductModel model);

        public ProductResponseModel UpdateProduct(Guid id, UpdateProductModel model);


    }
}
