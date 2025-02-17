using Microsoft.EntityFrameworkCore;
using RenterScoreAPI.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

    public DbSet<UserProfile> UserProfiles { get; set; }
}