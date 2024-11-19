using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class ProjectPaggingFreelancerDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public Guid PosterId { get; set; }
        public string PosterName { get; set; }
        public int BiddingCount { get; set; }

        public int BiddingMoney { get; set; }
        public DateTime EndDate { get; set; }
    }
}
