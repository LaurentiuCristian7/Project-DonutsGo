namespace DonutsGo.DataAccess.Entities
{
    public class User
    {
        public User()
        {
            Products =new List<ProductUser>();
        }
     
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public List<ProductUser> Products { get; set; }

    }
}
