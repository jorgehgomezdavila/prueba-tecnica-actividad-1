using Microsoft.EntityFrameworkCore;
using Backend_PT1.Models;

namespace Backend_PT1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<SearchLog> SearchHistory { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<SearchLog>().ToTable("SearchHistory");
    }
}