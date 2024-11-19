using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class Field
    {
        [Key]
        public Guid FieldId { get; set; }
        [Column(TypeName ="nvarchar(50)")]
        public string FieldName { get; set; }
        public ICollection<UserCV>userCVs { get; set; }
        public ICollection<Project> projects { get; set; }
    }
}
