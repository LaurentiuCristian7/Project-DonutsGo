namespace DonutsGo.DataAccess.Entities;

public class Product
{
    public Product()
    {
        CreatedAt = DateTime.Now;
    }
    public Guid Id { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public ProductType Type { get; set; }


    public DateTime CreatedAt { get; set; }

    public List<ProductUser>Users { get; set; }

         

}

public enum ProductType
{
    Donuts = 1,
    Waffles = 2,
    Drinks = 3
}