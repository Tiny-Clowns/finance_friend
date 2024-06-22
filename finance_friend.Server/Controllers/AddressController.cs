using finance_friend.Server.DAL;
using finance_friend.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace finance_friend.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly AddressDao _dao;
        public AddressController(AddressDao dao)
        {
            _dao = dao;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await _dao.GetAddresses();
            return Ok(addresses);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAddress([FromBody] Address address)
        {
            var successful = await _dao.CreateAddress(address);
            return Ok(successful);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAddress([FromBody] Address address)
        {
            var successful = await _dao.UpdateAddress(address);
            return Ok(successful);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAddress([FromBody] int addressId)
        {
            var successful = await _dao.DeleteAddress(addressId);
            return Ok(successful);
        }
    }
}
