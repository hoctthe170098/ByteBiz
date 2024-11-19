using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class ProjectDTO
    {
        public Guid Id { get; set; }
        public string avatarPoster {  get; set; }
        public string namePoster { get; set; }
        public string Title { get; set; }
        public string  Description { get; set; }
        public string Address { get; set; }
        public string FormOfWork { get; set; }
        public string FieldName { get; set; }
        public int BudgetFrom { get; set; }
        public int BudgetTo { get; set; }
        public DateTime EndDate { get; set; }
        public int BiddingCount { get; set; }
    }
}
