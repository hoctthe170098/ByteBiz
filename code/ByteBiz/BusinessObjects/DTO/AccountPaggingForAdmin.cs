using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class AccountPaggingForAdmin
    {
        public int total { get; set; }
        public int page { get; set; }
        public List<AccountForAdminDTO> listAccount { get; set; }
    }
}
