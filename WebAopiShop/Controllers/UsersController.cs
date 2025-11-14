using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using WebAopiShop;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        string filePath = "users.txt";
        UserService service = new UserService();

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };

        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = service.GetUserById(id);
            if (user == null)
            {
                return NoContent();
            }
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost("Login")]
        public ActionResult<User> Login([FromBody] ExistUser val)
        {
            User user = service.LogIn(val);
            if (user == null)
            {
                return NoContent();
            }
            return Ok(user);
        }

        [HttpPost("Register")]
        public ActionResult<User> Register([FromBody] User val)
        {
            User user = service.AddUser(val);
            if (user == null)
            {
                return BadRequest("Password too weak");
            }
            return CreatedAtAction(nameof(Get), new {user.userId},user);

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            service.UpdateUser(value,id);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
