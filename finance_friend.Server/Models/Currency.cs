namespace finance_friend.Server.Models
{
    public class Currency
    {
        public required int CurrencyId { get; set; }
        public required string CurrencyCode { get; set; }
        public required string Unit { get; set; }
        public required string Description { get; set; }
    }
}
