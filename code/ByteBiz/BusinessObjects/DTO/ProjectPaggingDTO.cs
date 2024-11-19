using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class ProjectPaggingDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int BiddingCount { get; set; }
        public Guid? ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public DateTime EndDate { get; set; }
    }
}
