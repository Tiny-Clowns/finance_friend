using System.Data;
using MySql.Data.MySqlClient;

namespace finance_friend.Server.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public required string Username { get; set; }
        public decimal BalanceUSD { get; set; }
        public required string Email { get; set; }
        public required string MobileNumber { get; set; }
        public int AddressId { get; set; }
        public int? CompanyId { get; set; }
        public int UserTypeId { get; set; }
        public int CurrencyId { get; set; }
    }
}
