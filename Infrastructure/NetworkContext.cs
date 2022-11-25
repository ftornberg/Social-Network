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

    public DbSet<Conversation>? Conversations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

      builder.Entity<User>()
        .HasData(
          new User
          {
            Id = 1,
            UserId = 1,
            Name = "John",
            Email = "john@email.com",
            Password = "password",
            CreatedTime = DateTime.Now
          }
        );
    }
  }
}