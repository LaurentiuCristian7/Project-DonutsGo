using Microsoft.AspNetCore.Mvc;
using DonutsGo.DataAccess.Entities;
using DonutsGo.DataAccess;
using DonutsGo.Application.Services;
using DonutsGo.Shared.Users;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DonutsGo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class UsersController : ControllerBase
    {
        private readonly  IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService =userService;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult GetUsers()
        {
            var users = userService.GetAllUsers();

            return Ok(users);
        }

        //[HttpGet("{id}")]
        //[Authorize]
        //public IActionResult GetUserById(Guid id)
        //{
        //    var user = Storage.Users.FirstOrDefault(x => x.Id == id);

        //    return Ok(user);
        //}

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateUser(CreateUserRequestModel user)
        {
            var addedUser = this.userService.AddUser(user); 

            return Created( $"/users/{addedUser.Id}",addedUser);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginRequestModel model)
        {
            var response = await this.userService.LoginAsync(model);

            return Ok(response);
        }
    }
}
