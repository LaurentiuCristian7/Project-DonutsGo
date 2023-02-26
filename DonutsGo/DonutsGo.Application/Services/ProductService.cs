using DonutsGo.Application.Exceptions;
using DonutsGo.Application.Models.Products;
using DonutsGo.DataAccess;
using DonutsGo.DataAccess.Entities;

namespace DonutsGo.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext databaseContext;

        public ProductService(DatabaseContext databaseContext)
        {
            this.databaseContext =databaseContext;
        }

        public List<ProductResponseModel>GetAllProducts()
        {


          //  var products = Storage.Products.Select(x => new ProductResponseModel
          //  {
          //      Id= x.Id,
           //     Name= x.Name,
          //      Price = x.Price,
          //      Type = x.Type
          //  }).ToList();

            var products = this.databaseContext.Products.ToList();  
            
            var response =products.Select(x => new ProductResponseModel
            {
                  Id= x.Id,
                  Name= x.Name,
                  Price = x.Price,
                  Type = x.Type
            }).ToList();
            

            return response;
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

            this.databaseContext.Products.Add(product);

            this.databaseContext.SaveChanges(); 

            //Storage.Products.Add(product);

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
