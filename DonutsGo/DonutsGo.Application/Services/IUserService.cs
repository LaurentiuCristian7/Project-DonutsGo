using DonutsGo.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutsGo.Application.Services
{
    public interface IUserService
    {
        User AddUser(User user);

        List<User> GetAllUsers();
    }
}
