using DonutsGo.DataAccess;
using DonutsGo.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutsGo.Application.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext databaseContext;

        public UserService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<User> GetAllUsers()
        {
            return this.databaseContext.Users.ToList();
        }


        public User AddUser(User user)
        {
             var addedUser =this.databaseContext.Users.Add(user);

            this.databaseContext.SaveChanges();

            return addedUser.Entity;

        }
    }
}
