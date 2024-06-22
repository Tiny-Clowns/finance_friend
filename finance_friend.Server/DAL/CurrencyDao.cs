using finance_friend.Server.Models;
using MySql.Data.MySqlClient;

namespace finance_friend.Server.DAL
{
    public class CurrencyDao
    {
        private readonly string _connectionString;
        private readonly ILogger _logger;
        public CurrencyDao(IConfiguration config, ILogger<CurrencyDao> logger)
        {
            _connectionString = config.GetConnectionString("Main")!;
            _logger = logger;
        }

        private const string query_GetCurrencies = @"
select
c.CurrencyId
,c.CurrencyCode
,c.Unit
,c.Description
from currency c
";
        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            var currencies = new List<Currency>();

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_GetCurrencies, connection);
                var dr = await command.ExecuteReaderAsync();

                while (dr.Read())
                {
                    var i = -1;

                    currencies.Add(new Currency
                    {
                        CurrencyId = dr.GetInt32(++i),
                        CurrencyCode = dr.GetString(++i),
                        Unit = dr.GetString(++i),
                        Description = dr.GetString(++i),
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return currencies;
        }

        private const string query_CreateCurrency = @"
insert into currency
(
    CurrencyCode
    ,Unit
    ,Description
)
values
(
    @pCurrencyCode
    ,@pUnit
    ,@pDescription
)
";
        public async Task<bool> CreateCurrency(Currency currency)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_CreateCurrency, connection);

                command.Parameters.Add(new MySqlParameter("@pCurrencyCode", currency.CurrencyCode));
                command.Parameters.Add(new MySqlParameter("@pUnit", currency.Unit));
                command.Parameters.Add(new MySqlParameter("@pDescription", currency.Description));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }

        private const string query_UpdateCurrency = @"
update currency
set 
    CurrencyCode = @pCurrencyCode
    ,Unit = @pUnit
    ,Description = @pDescription
where 
    CurrencyId = @pCurrencyId
";
        public async Task<bool> UpdateCurrency(Currency currency)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_UpdateCurrency, connection);

                command.Parameters.Add(new MySqlParameter("@pCurrencyCode", currency.CurrencyCode));
                command.Parameters.Add(new MySqlParameter("@pUnit", currency.Unit));
                command.Parameters.Add(new MySqlParameter("@pDescription", currency.Description));
                command.Parameters.Add(new MySqlParameter("@pCurrencyId", currency.CurrencyId));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }

        private const string query_DeleteCurrency = @"
delete currency
where CurrencyId = @pCurrencyId
";
        public async Task<bool> DeleteCurrency(int currencyId)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_DeleteCurrency, connection);

                command.Parameters.Add(new MySqlParameter("@pCurrencyId", currencyId));

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
