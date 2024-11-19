using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class Notification
    {
        [Key]
        public Guid NotificationId { get; set; }
        public Guid ReceiverId { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string Content { get; set; }
        public ApplicationUser Receiver { get; set; }
    }
}
