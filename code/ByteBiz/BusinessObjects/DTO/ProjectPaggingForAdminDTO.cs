using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class ProjectPaggingForAdminDTO
    {
        public List<ProjectForAdminDTO> Projects { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
