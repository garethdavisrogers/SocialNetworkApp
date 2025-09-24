using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetworkApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // temp in-memory store; swap for EF Core later
        private static readonly List<UserDto> Users = new()
        {
            new UserDto(Guid.NewGuid(), "Alice"),
            new UserDto(Guid.NewGuid(), "Bob"),
        };
        
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll() => Ok(Users);

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(Guid id)
        {
            UserDto user = Users.FirstOrDefault(u => u.Id == id);
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

        // DTOs: the API contract (what you send/receive)
        public record UserDto(Guid Id, string DisplayName);
        public record CreateUserDto(string DisplayName);
        public record UpdateUserDto(string? DisplayName);

    }
}
