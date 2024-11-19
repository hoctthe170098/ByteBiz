using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class UserCV
    {
        [Key]
        public Guid UserId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string UserCVImg { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string ProfessionalTitle { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Introdution { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string WebsiteUrl { get; set; }
        public Guid FieldId { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Level { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Skill { get; set; }
        public Field Field { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
