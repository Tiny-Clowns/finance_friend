using finance_friend.Server.Models;
using MySql.Data.MySqlClient;

namespace finance_friend.Server.DAL
{
    public class ExpenseDao
    {
        private readonly string _connectionString;
        private readonly ILogger _logger;
        public ExpenseDao(IConfiguration config, ILogger<ExpenseDao> logger)
        {
            _connectionString = config.GetConnectionString("Main")!;
            _logger = logger;
        }

        private const string query_GetExpenses = @"
select
e.ExpenseId
,e.AmountUSD
,e.UserId
,e.Description
,e.Timestamp
from expense e
";
        public async Task<IEnumerable<Expense>> GetExpenses()
        {
            var expenses = new List<Expense>();

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_GetExpenses, connection);
                var dr = await command.ExecuteReaderAsync();

                while (dr.Read())
                {
                    var i = -1;

                    expenses.Add(new Expense
                    {
                        ExpenseId = dr.GetInt32(++i),
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

            return expenses;
        }

        private const string query_CreateExpense = @"
insert into expense
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
        public async Task<bool> CreateExpense(Expense expense)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_CreateExpense, connection);

                command.Parameters.Add(new MySqlParameter("@pAmountUSD", expense.AmountUSD));
                command.Parameters.Add(new MySqlParameter("@pUserId", expense.UserId));
                command.Parameters.Add(new MySqlParameter("@pDescription", expense.Description));
                command.Parameters.Add(new MySqlParameter("@pTimestamp", expense.Timestamp));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }

        private const string query_UpdateExpense = @"
update expense
set 
    AmountUSD = @pAmountUSD
    ,UserId = @pUserId
    ,Description = @pDescription
    ,Timestamp = @pTimestamp
where 
    ExpenseId = @pExpenseId
";
        public async Task<bool> UpdateExpense(Expense expense)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_UpdateExpense, connection);

                command.Parameters.Add(new MySqlParameter("@pAmountUSD", expense.AmountUSD));
                command.Parameters.Add(new MySqlParameter("@pUserId", expense.UserId));
                command.Parameters.Add(new MySqlParameter("@pDescription", expense.Description));
                command.Parameters.Add(new MySqlParameter("@pTimestamp", expense.Timestamp));
                command.Parameters.Add(new MySqlParameter("@pExpenseId", expense.ExpenseId));

                result = await command.ExecuteNonQueryAsync() == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed execution.");
            }

            return result;
        }

        private const string query_DeleteExpense = @"
delete expense
where ExpenseId = @pExpenseId
";
        public async Task<bool> DeleteExpense(int expenseId)
        {
            var result = false;

            try
            {
                var connection = new MySqlConnection
                {
                    ConnectionString = _connectionString
                };
                connection.Open();

                var command = new MySqlCommand(query_DeleteExpense, connection);

                command.Parameters.Add(new MySqlParameter("@pExpenseId", expenseId));

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
