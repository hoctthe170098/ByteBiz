using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public  class MyDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public MyDbContext()
        {

        }
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfiguration configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
            }
        }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<ApplicationUserProfile> ApplicationUserProfiles { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<UserCV> UserCVs { get; set; }
        public virtual DbSet<AccountUpgrade> AccountUpgrades { get; set; }
        public virtual DbSet<CommentAndRate> CommentAndRates { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectBidding> ProjectBiddings { get; set; }
        public virtual DbSet<UpgradeHistory> UpgradeHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.ApplicationUserProfile)
                .WithOne(b => b.ApplicationUser)
                .HasForeignKey<ApplicationUserProfile>(b => b.UserId);
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a=>a.UserCV)
                .WithOne(b=>b.ApplicationUser)
                .HasForeignKey<UserCV>(b=>b.UserId);
            modelBuilder.Entity<UserCV>()
                .HasOne(a=>a.Field)
                .WithMany(b=>b.userCVs)
                .HasForeignKey(b=>b.FieldId);
            modelBuilder.Entity<Project>()
                .HasOne(a=>a.PosterUser)
                .WithMany(b=>b.PostProjects)
                .HasForeignKey(b=>b.PosterId);
            modelBuilder.Entity<Project>()
                .HasOne(a => a.ReceiverUser)
                .WithMany(b => b.ReceiveProjects)
                .HasForeignKey(b => b.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Project>()
                .HasOne(a=>a.Field)
                .WithMany(b=>b.projects)
                .HasForeignKey(b=>b.FieldId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProjectBidding>()
                .HasKey(p => new { p.BidderId, p.ProjectId });
            modelBuilder.Entity<ProjectBidding>()
                .HasOne(a=>a.Project)
                .WithMany(b=>b.ProjectBiddings)
                .HasForeignKey(b=>b.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ProjectBidding>()
                .HasOne(a => a.Bidder)
                .WithMany(b => b.ProjectBiddings)
                .HasForeignKey(b => b.BidderId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UpgradeHistory>()
                .HasKey(u => new { u.AccountUpgradeId, u.UserId, u.DateBuy });
            modelBuilder.Entity<UpgradeHistory>()
                .HasOne(a=>a.AccountUpgrade)
                .WithMany(b=>b.UpgradeHistories)
                .HasForeignKey(b=>b.AccountUpgradeId);
            modelBuilder.Entity<UpgradeHistory>()
                .HasOne(a => a.UserBuy)
                .WithMany(b => b.UpgradeHistories)
                .HasForeignKey(b => b.UserId);
            //modelBuilder.Entity<Payment>()
            //    .HasKey(p => new { p.UserId, p.Date });
            modelBuilder.Entity<Payment>()
                .HasOne(a=>a.ApplicationUser)
                .WithMany(b=>b.Payments)
                .HasForeignKey(b=>b.UserId);
            modelBuilder.Entity<Payment>()
                .HasOne(a => a.AccountUpgrade)
                .WithMany(b => b.Payments)
                .HasForeignKey(b => b.AccountUpgradeId);
            modelBuilder.Entity<Notification>()
                .HasOne(a=>a.Receiver)
                .WithMany(b=>b.Notifications)
                .HasForeignKey(b=>b.ReceiverId);
            modelBuilder.Entity<CommentAndRate>()
                .HasKey(c => new { c.FreelancerId, c.CustomerId });
            modelBuilder.Entity<CommentAndRate>()
                .HasOne(a=>a.Freelancer)
                .WithMany(b=>b.CommentedsAndRateds)
                .HasForeignKey(b=>b.FreelancerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<CommentAndRate>()
                .HasOne(a => a.Customer)
                .WithMany(b => b.CommentsAndRates)
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
