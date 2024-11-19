using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class ProfileDTO
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string FacebookLink { get; set; }
        public string OtherLink { get; set; }
        public string IdentifierName { get; set; }
        public string IdentifierId { get; set; }
        public DateTime Dob { get; set; }
        public string Role  { get; set; }
    }
}
