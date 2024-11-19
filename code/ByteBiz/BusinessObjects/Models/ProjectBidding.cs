using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class ProjectBidding
    {
        public Guid ProjectId { get; set; }
        public Guid BidderId { get; set; }
        public DateTime DateBidding { get; set; }
        public int MoneyBidding { get; set; }
        public ApplicationUser Bidder { get; set; }
        public Project Project { get; set; }
    }
}
