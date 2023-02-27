namespace DonutsGo.DataAccess.Entities
{
    public class User
    {
        public User()
        {
            Products =new List<ProductUser>();
        }
     

    
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public List<ProductUser> Products { get; set; }

    }
}
