using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
  }

}