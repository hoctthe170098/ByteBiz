using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class Project
    {
        [Key]
        public Guid ProjectId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndDate { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Address { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        public int BudgetFrom { get; set; }
        public int BudgetTo { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string FormOfWork { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Status { get; set; }
        public Guid PosterId { get; set; }
        public Guid? ReceiverId { get; set; }
        public Guid FieldId { get; set; }
        public ApplicationUser PosterUser { get; set; }
        public ApplicationUser ReceiverUser { get; set; }
        public Field Field { get; set; }
        public Collection<ProjectBidding>ProjectBiddings { get; set; }
    }
}
