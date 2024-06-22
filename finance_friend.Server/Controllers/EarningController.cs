using finance_friend.Server.DAL;
using finance_friend.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace finance_friend.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EarningController : ControllerBase
    {
        private readonly EarningDao _dao;
        public EarningController(EarningDao dao)
        {
            _dao = dao;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetEarnings()
        {
            var earnings = await _dao.GetEarnings();
            return Ok(earnings);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateEarning([FromBody] Earning earning)
        {
            var successful = await _dao.CreateEarning(earning);
            return Ok(successful);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateEarning([FromBody] Earning earning)
        {
            var successful = await _dao.UpdateEarning(earning);
            return Ok(successful);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteEarning([FromBody] int earningId)
        {
            var successful = await _dao.DeleteEarning(earningId);
            return Ok(successful);
        }
    }
}
