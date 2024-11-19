using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class AccountDTO
    {
        public Guid Id { get; set; }
        public string username { get; set; }
        public string role {  get; set; }
        public string fullname  { get; set; }
    }
}
