using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class AccountUpgrade
    {
        [Key]
        public Guid AccountUpgradeId { get; set; }
        [Column(TypeName ="nvarchar(20)")]
        public string AccountUpgradeName { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string AccountUpgradeType { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string AccountUpgradeDescription { get; set; }

        public int Month {  get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Money { get; set; }
        public float Discount { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public Collection<UpgradeHistory> UpgradeHistories { get; set; }
        public Collection<Payment> Payments { get; set; }
    }
}
