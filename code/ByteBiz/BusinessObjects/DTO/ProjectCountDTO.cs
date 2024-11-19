using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class ProjectCountDTO
    {
        public int ProjectBidding { get; set; }

        public int ProjectWaiting { get; set; }
        public int ProjectDone { get; set; }
        public int ProjectCancel { get; set; }
    }
}
