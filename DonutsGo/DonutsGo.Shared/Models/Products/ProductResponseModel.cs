namespace DonutsGo.Shared.Models.Products;

public partial class ProductResponseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public ProductTypeResponseModel Type { get; set; }
}