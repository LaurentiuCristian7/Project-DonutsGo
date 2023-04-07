using DonutsGo.DataAccess.Entities;
using DonutsGo.Shared.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutsGo.Application.Services;


 public interface IUserService
 { 
    UserResponseModel AddUser(CreateUserRequestModel userRequest);

    List<UserResponseModel> GetAllUsers();

    Task<LoginResponseModel> LoginAsync(LoginRequestModel model);

    Task<UserResponseModel> GetByIdAsync(Guid id);
 }
    

