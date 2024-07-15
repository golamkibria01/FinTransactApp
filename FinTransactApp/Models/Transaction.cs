namespace FinTransactApp.Models
{
    public class Transaction
    {
        public DateTime? TransactionDate { get; set; }

        public decimal? TransactionAmount { get; set; }

        public long? AccountInformationId { get; set; }

        public string AccountNumber { get; set; }

        public int? TransactionTypeId { get; set; }

        public string TransactionType { get; set; }
    }
}
 