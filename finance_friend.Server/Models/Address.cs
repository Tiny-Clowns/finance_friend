using System.Data.Common;
using finance_friend.Server.Utils;

namespace finance_friend.Server.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }

        public Address(DbDataReader dr)
        {
            var i = -1;
            AddressId = dr.GetInt32(++i);
            Address1 = dr.GetString(++i);
            Address2 = dr.Get<string?>(++i);
            Address3 = dr.Get<string?>(++i);
            City = dr.GetString(++i);
            State = dr.Get<string?>(++i);
            Country = dr.GetString(++i);
            PostCode = dr.GetString(++i);
        }
    }
}
