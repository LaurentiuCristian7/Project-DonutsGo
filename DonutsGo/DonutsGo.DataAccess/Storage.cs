using DonutsGo.DataAccess.Entities;
using DonutsGo.WebUI.Pages.Products;

namespace DonutsGo.DataAccess
{
    public static class Storage
    {
        public static List<Product> Products { get; set; } = new List<Product>();


        public static List<User> Users { get; set; } = new List<User>();
    }
}
