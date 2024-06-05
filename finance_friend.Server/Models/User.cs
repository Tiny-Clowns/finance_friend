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
        public decimal BalanceDollars { get; set; }
        public required string Email { get; set; }
        public required string MobileNumber { get; set; }
        public int AddressId { get; set; }
        public int? CompanyId { get; set; }
        public int UserTypeId { get; set; }
        public int CurrencyId { get; set; }

        // TODO: Change ids to models
        public User(MySqlDataReader dr)
        {
            var i = -1;
            UserId = dr.GetInt32(++i);
            LastName = dr.GetString(++i);
            FirstName = dr.GetString(++i);
            Username = dr.GetString(++i);
            BalanceDollars = dr.GetDecimal(++i);
            Email = dr.GetString(++i);
            MobileNumber = dr.GetString(++i);
            AddressId = dr.GetInt32(++i);
            CompanyId = dr.GetFieldValue<int?>(++i);
            UserTypeId = dr.GetInt32(++i);
            CurrencyId = dr.GetInt32(++i);
        }
    }
}
