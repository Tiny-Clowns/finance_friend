namespace finance_friend.Server.Models
{
    public class Company
    {
        public required int CompanyId { get; set; }
        public required string Name { get; set; }
        public required int AddressId { get; set; }
    }
}
