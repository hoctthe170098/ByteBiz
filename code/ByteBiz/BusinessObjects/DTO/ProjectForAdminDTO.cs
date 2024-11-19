using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class ProjectForAdminDTO
    {
        public string Title { get; set; }
        public string Poster { get; set; }
        public string Receiver { get; set; }
        public int BidCount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Status { get; set; }
    }
}
