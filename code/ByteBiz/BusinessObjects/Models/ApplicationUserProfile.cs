using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class ApplicationUserProfile
    {
        [Key]
        public Guid UserId { get; set; }
        [Column(TypeName ="nvarchar(30)")]
        public string FullName { get; set; }
        //biet danh
        [Column(TypeName = "nvarchar(10)")]
        public string Skype { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Avatar {  get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string FacebookLink { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string OtherLink { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string IdentifierName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string IdentifierId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Dob { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
