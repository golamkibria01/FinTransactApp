using System.ComponentModel.DataAnnotations;

namespace FinTransactApp.Models
{
    public class AccountInformation
    {
        public long AccountInformationId { get; set; }

        public string AccountName { get; set; }

        public string AccountNumber { get; set; }

        public string AccountHolderName { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public string HomeAddress { get; set; }

        public int UserId { get; set; }
    }
}
 