using finance_friend.Server.DAL;
using finance_friend.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace finance_friend.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyDao _dao;
        public CompanyController(CompanyDao dao)
        {
            _dao = dao;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _dao.GetCompanies();
            return Ok(companies);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            var successful = await _dao.CreateCompany(company);
            return Ok(successful);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateCompany([FromBody] Company company)
        {
            var successful = await _dao.UpdateCompany(company);
            return Ok(successful);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteCompany([FromBody] int companyId)
        {
            var successful = await _dao.DeleteCompany(companyId);
            return Ok(successful);
        }
    }
}
