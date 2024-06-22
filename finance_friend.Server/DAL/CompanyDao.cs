using finance_friend.Server.Models;
using MySql.Data.MySqlClient;

namespace finance_friend.Server.DAL
{
    public class CompanyDao
    {
        private readonly string _connectionString;
        private readonly ILogger _logger;
        public CompanyDao(IConfiguration config, ILogger<CompanyDao> logger)
        {
            _connectionString = config.GetConnectionString("Main")!;
            _logger = logger;
        }

        private const string query_GetCompanies = @"
select
c.CompanyId
,c.Name
,c.AddressId
from company c
";
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var companies = new List<Company>();

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_GetCompanies, connection);
                var dr = await command.ExecuteReaderAsync();

                while (dr.Read())
                {
                    var i = -1;

                    companies.Add(new Company
                    {
                        CompanyId = dr.GetInt32(++i),
                        Name = dr.GetString(++i),
                        AddressId = dr.GetInt32(++i),
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return companies;
        }

        private const string query_CreateCompany = @"
insert into company
(
    Name
    ,AddressId
)
values
(
    @pName
    ,@pAddressId
)
";
        public async Task<bool> CreateCompany(Company company)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_CreateCompany, connection);

                command.Parameters.Add(new MySqlParameter("@pName", company.Name));
                command.Parameters.Add(new MySqlParameter("@pAddressId", company.AddressId));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }

        private const string query_UpdateCompany = @"
update company
set 
    Name = @pName
    ,AddressId = @pAddressId
where 
    CompanyId = @pCompanyId
";
        public async Task<bool> UpdateCompany(Company company)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_UpdateCompany, connection);

                command.Parameters.Add(new MySqlParameter("@pName", company.Name));
                command.Parameters.Add(new MySqlParameter("@pAddressId", company.AddressId));
                command.Parameters.Add(new MySqlParameter("@pCompanyId", company.CompanyId));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }

        private const string query_DeleteCompany = @"
delete company
where CompanyId = @pCompanyId
";
        public async Task<bool> DeleteCompany(int companyId)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_DeleteCompany, connection);

                command.Parameters.Add(new MySqlParameter("@pCompanyId", companyId));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }
    }
}
