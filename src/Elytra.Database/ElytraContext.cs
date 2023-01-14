using Elytra.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Elytra.Database
{
    public class ElytraContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Message>? Messages { get; set; }

        public ElytraContext(DbContextOptions<ElytraContext> options)
            : base(options)
        { }
    }
}
