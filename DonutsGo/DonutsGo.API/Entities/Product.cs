namespace DonutsGo.API.Entities;

public class Product
{ 
    public Guid Id { get; set; }
    public string Name { get; set; }   
    public double Price { get; set; }
    public ProductType Type { get; set; }


}

public enum ProductType
{
    Donut = 1,
    Juice =2,
    Waffles =3
}