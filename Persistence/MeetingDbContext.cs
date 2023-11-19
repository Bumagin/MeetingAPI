using System.Text.Json.Serialization.Metadata;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityTypeConfiguration;

namespace Persistence;

public class MeetingDbContext : DbContext, IInteresDbContext, IUserDbContext
{ 
    public DbSet<Interes> Interests { get; set; }
    public DbSet<User> Users { get; set; }
    
    public MeetingDbContext(DbContextOptions<MeetingDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new InteresConfiguration());
        base.OnModelCreating(builder);
    }
}