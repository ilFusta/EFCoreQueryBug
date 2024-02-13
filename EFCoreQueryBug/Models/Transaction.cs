namespace EFCoreQueryBug.Models
{
    internal class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Statement> Statements { get; set; }
    }
    
}
