namespace finance_friend.Server.Models
{
    public class Expense
    {
        public required int ExpenseId { get; set; }
        public required decimal AmountUSD { get; set; }
        public required int UserId { get; set; }
        public string? Description { get; set; }
        public required DateTime Timestamp { get; set; }
    }
}
