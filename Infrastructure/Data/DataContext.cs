using Domain.Models;
using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Data;

public class DataContext:DbContext
{
public DataContext(DbContextOptions<DataContext> options) :base(options)
    {

    }

    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Participant> Participants { get; set; }

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
        
    // }
}
