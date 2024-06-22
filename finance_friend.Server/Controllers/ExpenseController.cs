using finance_friend.Server.DAL;
using finance_friend.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace finance_friend.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseDao _dao;
        public ExpenseController(ExpenseDao dao)
        {
            _dao = dao;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetExpenses()
        {
            var expenses = await _dao.GetExpenses();
            return Ok(expenses);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateExpense([FromBody] Expense expense)
        {
            var successful = await _dao.CreateExpense(expense);
            return Ok(successful);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateExpense([FromBody] Expense expense)
        {
            var successful = await _dao.UpdateExpense(expense);
            return Ok(successful);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteExpense([FromBody] int expenseId)
        {
            var successful = await _dao.DeleteExpense(expenseId);
            return Ok(successful);
        }
    }
}
