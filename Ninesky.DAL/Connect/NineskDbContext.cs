using Ninesky.Models;
using System.Data.Entity;

namespace Ninesky.DAL
{
    public class NineskDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<UserRoleRelation> UserRoleRelation { get; set; }

        public DbSet<UserConfig> UserConfig { get; set; }

        public NineskDbContext() : base("DefaultConnection")
        {
        }
    }
}