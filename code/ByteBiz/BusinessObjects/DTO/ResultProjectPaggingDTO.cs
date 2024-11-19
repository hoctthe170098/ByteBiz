using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class ResultProjectPaggingDTO
    {
        public int total { get; set; }
        public int page { get; set; }
        public List<ProjectPaggingDTO> projects { get; set; }
        public string StatusProject { get; set; }
    }
}
