using Microsoft.AspNetCore.Mvc;
using DonutsGo.API.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DonutsGo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = Storage.Users;

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
            Storage.Users.Add(user);

            return Created( $"/users/{user.Id}",user);
        }
    }
}
