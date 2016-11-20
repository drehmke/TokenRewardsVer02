using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TokenRewardsVer02.Models;

namespace TokenRewardsVer02.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<UserAchievements> UserAchievements { get; set; }
        public DbSet<UserRewards> UserRewards { get; set; }
        public DbSet<AchievementCategory> AchievementCategories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserAchievements>().HasKey(x => new { x.UserID, x.AchievementId });
            builder.Entity<UserRewards>().HasKey(x => new { x.UserId, x.RewardId });
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
