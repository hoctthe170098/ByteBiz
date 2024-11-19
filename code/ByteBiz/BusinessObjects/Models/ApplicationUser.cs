
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {       
        public int LoginCount { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime? LastLoginTime { get; set; }
        public ApplicationUserProfile ApplicationUserProfile { get; set; }
        public UserCV UserCV { get; set; }
        public Collection<Project> PostProjects { get; set; }
        public Collection<Project> ReceiveProjects{ get;set; }
        public Collection<ProjectBidding> ProjectBiddings { get;set; }
        public Collection<UpgradeHistory> UpgradeHistories  { get; set; }
        public Collection<Payment>Payments { get; set; }
        public Collection<Notification> Notifications { get; set; }
        public Collection<CommentAndRate> CommentsAndRates { get; set; }
        public Collection<CommentAndRate> CommentedsAndRateds { get; set; }
    }
}
