using finance_friend.Server.DAL;
using finance_friend.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace finance_friend.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyDao _dao;
        public CurrencyController(CurrencyDao dao)
        {
            _dao = dao;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetCurrencies()
        {
            var currencies = await _dao.GetCurrencies();
            return Ok(currencies);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCurrency([FromBody] Currency currency)
        {
            var successful = await _dao.CreateCurrency(currency);
            return Ok(successful);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateCurrency([FromBody] Currency currency)
        {
            var successful = await _dao.UpdateCurrency(currency);
            return Ok(successful);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteCurrency([FromBody] int currencyId)
        {
            var successful = await _dao.DeleteCurrency(currencyId);
            return Ok(successful);
        }
    }
}
