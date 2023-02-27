using Microsoft.AspNetCore.Mvc;
using DonutsGo.DataAccess.Entities;
using DonutsGo.DataAccess;
using DonutsGo.Application.Services;
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
        public IActionResult GetUsers()
        {
            var users = userService.GetAllUsers();

            return Ok(users);
        }
        [HttpGet("{id}")]  
        public IActionResult GetUserById(Guid id)
        {
            var user = Storage.Users.FirstOrDefault(x => x.Id == id);

            return Ok(user);   
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            var addedUser = this.userService.AddUser(user); 

            return Created( $"/users/{addedUser.Id}",addedUser);
        }
    }
}
