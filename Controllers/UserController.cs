using Microsoft.AspNetCore.Mvc;
using SocialNetworkApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetworkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // temp in-memory store; swap for EF Core later
        private static readonly List<User> Users = new()
        {
            new User("Alice"),
            new User("Bob"),
        };
        
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll() => Ok(Users);

        // GET api/<UserController>/5
        [HttpGet("{name}")]
        public ActionResult<User> Get(string name)
        {
            User user = Users.FirstOrDefault(u => u.Name == name);
            return user is null ? NotFound() : Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
