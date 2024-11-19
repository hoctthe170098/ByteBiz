using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }  
        public DateTime UpdatedAt { get; set; }
        public string PaymentDetails { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public Decimal Money { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string TransactionId { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string PaymentStatus { get; set; }
        public Guid AccountUpgradeId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public AccountUpgrade AccountUpgrade { get; set; }
    }
}
