using DonutsGo.Application.Exceptions;
using DonutsGo.Application.Models.Users;
using DonutsGo.DataAccess;
using DonutsGo.DataAccess.Entities;
using DonutsGo.Shared.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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

        public UserResponseModel AddUser(CreateUserRequestModel userRequest)
        {
            var addedUser = this.databaseContext.Users.Add(userRequest.ToUser()).Entity;

            this.databaseContext.SaveChanges();

            return UserMapper.FromUser(addedUser);
        }


        public List<UserResponseModel> GetAllUsers()
        {
            var usersFromDatabase = this.databaseContext.Users.ToList();

            var response = new List<UserResponseModel>();

            foreach (var user in usersFromDatabase)
            {
                response.Add(UserMapper.FromUser(user));
            }

            return response;
        }


        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel model)
        {
            var user = await this.databaseContext.Users.FirstOrDefaultAsync(u => u.Username == model.Username);

            if (user == null)
            {
                throw new NotFoundException("Username or password is incorrect.");
            }

            if (user.Password != model.Password)
            {
                throw new NotFoundException("Username or password is incorrect.");
            }

            var token = JwtHelper.GenerateToken(user, "MySuperSecretKey");

            return new LoginResponseModel
            {
                Username = user.Username,
                Id = user.Id,
                Email = user.Email,
                Token = token
            };
        }

        public async Task<UserResponseModel> GetByIdAsync(Guid id)
        {
            var userFromDatabase = await this.databaseContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (userFromDatabase == null)
            {
                throw new NotFoundException("User info not found.");
            }

            return UserMapper.FromUser(userFromDatabase);
        }



        public static class JwtHelper
        {
            public static string GenerateToken(User user, string secretKey)
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var claims = new List<Claim>()
                {
                   new Claim("id", user.Id.ToString()),
                   new Claim(ClaimTypes.Name, user.Username),
                   new Claim(ClaimTypes.Email, user.Email)
                };

                if (user.Username == "admin")
                {
                   claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }

                var claimsIdentity = new ClaimsIdentity(claims);

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new List<Claim>()
                    {
                       new Claim("id",user.Id.ToString()),
                       new Claim(ClaimTypes.Name,user.Username),
                       new Claim(ClaimTypes.Email,user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }

        }
    }
}
