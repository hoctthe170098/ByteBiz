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
    public class CvDTO
    {
        public Guid UserId { get; set; }
        public string UserCVImg { get; set; }
        public string ProfessionalTitle { get; set; }
        public string Introdution { get; set; }
        public string WebsiteUrl { get; set; }
        public Guid FieldId { get; set; }
        public string FieldName { get; set; }
        public string Level { get; set; }
        public string Skill { get; set; }
    }
}
