using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class FullInformationFreelancerDTO
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
        public DateTime Dob { get; set; }
        public string UserCVImg { get; set; }
        public string ProfessionalTitle { get; set; }
        public string Introdution { get; set; }
        public string WebsiteUrl { get; set; }
        public string FieldName { get; set; }
        public string Level { get; set; }
        public string Skill { get; set; }
    }
}
