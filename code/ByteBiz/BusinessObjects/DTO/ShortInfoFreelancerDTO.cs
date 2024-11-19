using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class ShortInfoFreelancerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int BidMoney { get; set; }
    }
}
