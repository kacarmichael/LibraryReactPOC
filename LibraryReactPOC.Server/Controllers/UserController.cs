using LibraryReactPOC.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace LibraryReactPOC.Server.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            foreach (User u in GenerateUsers())
            {
                Userbase.AddUser(u);
            }
        }

        
        public static IEnumerable<User> GenerateUsers()
        {
            return Enumerable.Range(1, 5).Select(index => new User(firstname: "Test", lastname: "User", email: "test@user.com")).ToArray();
        }


        [HttpGet("Users")]
        public ActionResult<List<User>> GetAllUsers() 
        {
            return Userbase.GetUsers();
        }

        [HttpGet("Users/{id}")]
        public ActionResult<User> GetUser(int id)
        {
            return Userbase.GetUser(id);
        }

        [HttpPost("User")]
        public void CreateUser(string firstname,  string lastname, string email)
        {
            Userbase.AddUser(new User(firstname, lastname, email));
        }
    }
}
