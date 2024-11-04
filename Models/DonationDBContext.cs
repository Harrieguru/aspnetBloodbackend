using Microsoft.EntityFrameworkCore;

namespace webAPI.Models
{
    public class DonationDBContext:DbContext
    {
        public DonationDBContext(DbContextOptions<DonationDBContext> options):base(options)
        {
                
        }
        public DbSet<DCandidate> DCandidates { get; set; }
    }
}

