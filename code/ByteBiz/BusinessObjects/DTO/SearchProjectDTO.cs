using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class SearchProjectDTO
    {
        public string Title { get; set; } = "";
        public Guid? FieldId { get; set; }
        public string Address { get; set; } = "";
    }
}
