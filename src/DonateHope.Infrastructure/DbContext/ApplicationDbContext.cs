using DonateHope.Domain.Entities;
using DonateHope.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DonateHope.Infrastructure.DbContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<AppUser, AppRole, Guid>(options)
{
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<CampaignRating> CampaignRatings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AppUser>(b =>
        {
            b.ToTable("app_users");
        });

        modelBuilder.Entity<IdentityUserClaim<Guid>>(b =>
        {
            b.ToTable("app_user_claims");
        });

        modelBuilder.Entity<IdentityUserLogin<Guid>>(b =>
        {
            b.ToTable("app_user_logins");
        });

        modelBuilder.Entity<IdentityUserToken<Guid>>(b =>
        {
            b.ToTable("app_user_tokens");
        });

        modelBuilder.Entity<AppRole>(b =>
        {
            b.ToTable("app_roles");
        });

        modelBuilder.Entity<IdentityRoleClaim<Guid>>(b =>
        {
            b.ToTable("app_role_claims");
        });

        modelBuilder.Entity<IdentityUserRole<Guid>>(b =>
        {
            b.ToTable("app_user_roles");
        });

        // app_users table
        modelBuilder.Entity<AppUser>().HasKey(user => user.Id);
        modelBuilder
            .Entity<AppUser>()
            .Ignore(user => user.CampaignRatings)
            .Ignore(user => user.Campaigns);

        // campaigns table
        modelBuilder.Entity<Campaign>().HasKey(c => c.Id);
        modelBuilder.Entity<Campaign>().Ignore(c => c.User).Ignore(c => c.CampaignRatings);
        modelBuilder
            .Entity<Campaign>()
            .HasOne<AppUser>()
            .WithMany(u => u.Campaigns)
            .HasForeignKey(c => c.UserId);

        // campaign_ratings table
        modelBuilder.Entity<CampaignRating>().HasKey(r => r.Id);
        modelBuilder.Entity<CampaignRating>().Ignore(cr => cr.Campaign).Ignore(cr => cr.User);
        modelBuilder
            .Entity<CampaignRating>()
            .HasOne<AppUser>()
            .WithMany(user => user.CampaignRatings)
            .HasForeignKey(cr => cr.UserId);
        modelBuilder
            .Entity<CampaignRating>()
            .HasOne<Campaign>()
            .WithMany(c => c.CampaignRatings)
            .HasForeignKey(cr => cr.CampaignId);
    }
}
