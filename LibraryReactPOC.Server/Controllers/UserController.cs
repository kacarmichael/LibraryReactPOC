using LibraryReactPOC.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

using LibraryReactPOC.Server.Infrastructure;

namespace LibraryReactPOC.Server.Controllers
{
    [ApiController]
    [Route("api/")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private LibraryDbContext _dbContext;

        public UserController(ILogger<UserController> logger, LibraryDbContext context)
        {
            _logger = logger;
            _dbContext = context;
            if (Userbase.GetUsers().Count == 0)
            {
                foreach (User u in GenerateUsers())
                {
                    Userbase.AddUser(u);
                }
            }   
        }

        
        public static IEnumerable<User> GenerateUsers()
        {
            return Enumerable.Range(1, 5).Select(index => new User(firstname: "Test", lastname: "User", email: "test@user.com", password: "password")).ToArray();
        }

        public void Add(User user)
        {
            _dbContext.User.Add(user);
        }

        public void Update(User user)
        {
            _dbContext.User.Update(user);
        }

        public void Delete(User user)
        {
            _dbContext.User.Remove(user);
        }

        public User Get(int id)
        {
            return _dbContext.User.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.User.ToList<User>();
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
        public void CreateUser(string firstname,  string lastname, string email, string password)
        {
            Userbase.AddUser(new User(firstname, lastname, email, password));
        }
    }
}
