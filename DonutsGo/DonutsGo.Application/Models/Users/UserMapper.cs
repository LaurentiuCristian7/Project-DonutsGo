using DonutsGo.DataAccess.Entities;
using DonutsGo.Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutsGo.Application.Models.Users;

public static class UserMapper
{
    public static UserResponseModel FromUser(User user)
    {
        return new UserResponseModel
        {
            Id = user.Id,
            Address = user.Address,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }

    public static User ToUser(this CreateUserRequestModel user)
    {
        return new User
        {
            Address = user.Address,
            Username = user.Username,
            Email = user.Email,
            Password = user.Password,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }
}

