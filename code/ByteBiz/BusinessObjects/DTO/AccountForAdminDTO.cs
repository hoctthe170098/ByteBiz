using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class AccountForAdminDTO
    {
        public Guid Id { get; set; }
        public string username { get; set; }
        public string role { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
    }
}
