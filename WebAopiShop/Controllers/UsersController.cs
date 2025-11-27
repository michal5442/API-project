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
        private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");
        private readonly UserService _userService = new UserService();

        

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<UsersController>
        [HttpPost("Login")]
        public ActionResult<User> Login([FromBody] ExistUser val)
        {
            User user = _userService.LogIn(val);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }

        [HttpPost("Register")]
        public ActionResult<User> Register([FromBody] User val)
        {
            User user = _userService.AddUser(val);
            if (user == null)
            {
                return BadRequest("Password too weak");
            }
            return CreatedAtAction(nameof(Get), new {user.userId},user);

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User value)
        {
            _userService.UpdateUser(value,id);
            return NoContent();
        }\n    }\n}
