using Microsoft.EntityFrameworkCore;

namespace EmiAPI.Models
{
    public class PolicyContext : DbContext
    {
        public PolicyContext(DbContextOptions<PolicyContext> options) : base(options) { }
        public DbSet<Policy> DbSet { get; set; } = null!;

    }
}
