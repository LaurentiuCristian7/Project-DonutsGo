using DonutsGo.Application.Exceptions;
using DonutsGo.Application.Models.Products;
using DonutsGo.DataAccess;
using DonutsGo.DataAccess.Entities;

namespace DonutsGo.Application.Services
{
    public class ProductService : IProductService
    {
        public ProductService(IDataAccessDemo dataAccessDemo)
        {
            Console.WriteLine();
        }

        public List<ProductResponseModel>GetAllProducts()
        {
            var products = Storage.Products.Select(x => new ProductResponseModel
            {
                Id= x.Id,
                Name= x.Name,
                Price = x.Price,
                Type = x.Type
            }).ToList();

            return products;
        }

        public ProductResponseModel CreateProduct(CreateProductModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ValidationException("Name cannot be null.");
            }

            if (model.Name.Length < 4)
            {
                throw new ValidationException("Name should  have lenght greater than 4.");
            }

            var product = new Product
            {
                Id =Guid.NewGuid(),
                Name = model.Name,
                Price = model.Price,
                Type = model.Type,
            };

            Storage.Products.Add(product);

          //  return new ProductResponseModel
          //  {
          //      Id =product.Id,
          //      Name = product.Name,
           //     Price=product.Price,
           //     Type=product.Type 
          //  };

            return ProductResponseModel.FromProduct(product);
        }




        public ProductResponseModel UpdateProduct( Guid id ,UpdateProductModel model)
        {

            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ValidationException("Name cannot be null.");
            }

            if (model.Name.Length < 4)
            {
                throw new ValidationException("Name should  have lenght greater than 4.");
            }


            var product = Storage.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new NotFoundException(string.Empty);
            }




            product.Name=model.Name;
            product.Price=model.Price;
            product.Type = model.Type;

          // // return new ProductResponseModel
          //  {
          //      Id =product.Id,
           //     Name = product.Name,
          //      Price=product.Price,
          //      Type=product.Type
          //  };

            return ProductResponseModel.FromProduct(product);
        }
    }
}
