using finance_friend.Server.DAL;
using finance_friend.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace finance_friend.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserDao _dao;
        public UserController(UserDao dao)
        {
            _dao = dao;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _dao.GetUsers();
            return Ok(users);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            var successful = await _dao.CreateUser(user);
            return Ok(successful);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            var successful = await _dao.UpdateUser(user);
            return Ok(successful);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteUser([FromBody] int userId)
        {
            var successful = await _dao.DeleteUser(userId);
            return Ok(successful);
        }
    }
}
