namespace EFCoreQueryBug.Models
{
    internal class Statement
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int ContactId { get; set; }
        public string Type { get; set; } //Client, Model, Agency
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool IsCommission { get; set; }
        public Transaction Tramsaction { get; set; }
        public Contact Contact { get; set; }
    }
}
