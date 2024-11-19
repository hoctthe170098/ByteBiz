using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class UpgradeHistory
    {
        public Guid UserId { get; set; }
        public Guid AccountUpgradeId { get; set; }
        public DateTime DateBuy { get; set; }
        public DateTime DateEnd { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Status { get; set; }
        public ApplicationUser UserBuy { get; set; }
        public AccountUpgrade AccountUpgrade { get; set; }
    }
}
