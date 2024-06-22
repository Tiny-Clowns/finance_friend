using finance_friend.Server.Models;
using MySql.Data.MySqlClient;

namespace finance_friend.Server.DAL
{
    public class EarningDao
    {
        private readonly string _connectionString;
        private readonly ILogger _logger;
        public EarningDao(IConfiguration config, ILogger<EarningDao> logger)
        {
            _connectionString = config.GetConnectionString("Main")!;
            _logger = logger;
        }

        private const string query_GetEarnings = @"
select
e.EarningId
,e.AmountUSD
,e.UserId
,e.Description
,e.Timestamp
from earning e
";
        public async Task<IEnumerable<Earning>> GetEarnings()
        {
            var earnings = new List<Earning>();

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_GetEarnings, connection);
                var dr = await command.ExecuteReaderAsync();

                while (dr.Read())
                {
                    var i = -1;

                    earnings.Add(new Earning
                    {
                        EarningId = dr.GetInt32(++i),
                        AmountUSD = dr.GetDecimal(++i),
                        UserId = dr.GetInt32(++i),
                        Description = dr.GetString(++i),
                        Timestamp = dr.GetDateTime(++i),
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return earnings;
        }

        private const string query_CreateEarning = @"
insert into earning
(
    AmountUSD
    ,UserId
    ,Description
    ,Timestamp
)
values
(
    @pAmountUSD
    ,@pUserId
    ,@pDescription
    ,@pTimestamp
)
";
        public async Task<bool> CreateEarning(Earning earning)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_CreateEarning, connection);

                command.Parameters.Add(new MySqlParameter("@pAmountUSD", earning.AmountUSD));
                command.Parameters.Add(new MySqlParameter("@pUserId", earning.UserId));
                command.Parameters.Add(new MySqlParameter("@pDescription", earning.Description));
                command.Parameters.Add(new MySqlParameter("@pTimestamp", earning.Timestamp));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }

        private const string query_UpdateEarning = @"
update earning
set 
    AmountUSD = @pAmountUSD
    ,UserId = @pUserId
    ,Description = @pDescription
    ,Timestamp = @pTimestamp
where 
    EarningId = @pEarningId
";
        public async Task<bool> UpdateEarning(Earning earning)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_UpdateEarning, connection);

                command.Parameters.Add(new MySqlParameter("@pAmountUSD", earning.AmountUSD));
                command.Parameters.Add(new MySqlParameter("@pUserId", earning.UserId));
                command.Parameters.Add(new MySqlParameter("@pDescription", earning.Description));
                command.Parameters.Add(new MySqlParameter("@pTimestamp", earning.Timestamp));
                command.Parameters.Add(new MySqlParameter("@pEarningId", earning.EarningId));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }

        private const string query_DeleteEarning = @"
delete earning
where EarningId = @pEarningId
";
        public async Task<bool> DeleteEarning(int earningId)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_DeleteEarning, connection);

                command.Parameters.Add(new MySqlParameter("@pEarningId", earningId));

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
