using System.Data.Common;
using finance_friend.Server.Utils;

namespace finance_friend.Server.Models
{
    public class Address
    {
        public required int AddressId { get; set; }
        public required string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public required string City { get; set; }
        public string? State { get; set; }
        public required string Country { get; set; }
        public required string PostCode { get; set; }
    }
}
