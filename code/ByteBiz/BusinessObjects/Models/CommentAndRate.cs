using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class CommentAndRate
    {
        public Guid CustomerId { get; set; }
        public Guid FreelancerId { get; set; }
        [Column(TypeName ="nvarchar(max)")]
        public string Comment { get; set; }
        [Range(1,5)]
        public int Rate { get; set; }
        public DateTime Date { get; set; }
        public ApplicationUser Customer { get; set; }
        public ApplicationUser Freelancer { get; set; }
    }
}
