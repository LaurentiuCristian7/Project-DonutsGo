

namespace DonutsGo.DataAccess.Entities
{
    public class ProductUser
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid ProductId { get; set; } 

        public Product Product { get; set; }
    }
}
