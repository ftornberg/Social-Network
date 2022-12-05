using System.Reflection;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
  public class NetworkContext : DbContext
  {
    public NetworkContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User>? Users { get; set; }

    public DbSet<Post>? Posts { get; set; }

    public DbSet<Comment>? Comments { get; set; }

    public DbSet<DirectMessage>? DirectMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
    }
  }
}