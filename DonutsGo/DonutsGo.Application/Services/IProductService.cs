using DonutsGo.Application.Models.Products;
using DonutsGo.Shared.Models;
using DonutsGo.Shared.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutsGo.Application.Services;

    public interface IProductService
{
         List<ProductResponseModel> GetAllProducts();

         ProductResponseModel CreateProduct(CreateProductRequestModel model);

         ProductResponseModel UpdateProduct(Guid id,UpdateProductRequestModel model);
    }

