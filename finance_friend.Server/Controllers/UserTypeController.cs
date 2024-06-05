using finance_friend.Server.DAL;
using finance_friend.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace finance_friend.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : ControllerBase
    {
        private readonly UserTypeDao _dao;
        public UserTypeController(UserTypeDao dao)
        {
            _dao = dao;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetUserTypes()
        {
            var userTypes = await _dao.GetUserTypes();
            return Ok(userTypes);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserType([FromBody] UserType userType)
        {
            var successful = await _dao.CreateUserType(userType);
            return Ok(successful);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateUserType([FromBody] UserType userType)
        {
            var successful = await _dao.UpdateUserType(userType);
            return Ok(successful);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteUserType([FromBody] int userTypeId)
        {
            var successful = await _dao.DeleteUserType(userTypeId);
            return Ok(successful);
        }

    }
}
