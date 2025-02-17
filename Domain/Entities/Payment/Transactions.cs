
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopClothing.Domain.Entities.Payment
{
    public class Transactions
    {
        public Guid TransactionID { get; set; }

        
        public Guid PaymentID { get; set; }

        public Guid PayerID { get; set; }

        public string Status { get; set; } = "Pending"; // . completed . failed

        public decimal Amount { get; set; }

        public string? Currency { get; set; } = "VND";

        public DateTime TransactionDate { get; set; }

        public string PaymentReference { get; set; } = null!;


        public PaymentMethod PaymentMethod { get; set; } = null!;





    }
}
