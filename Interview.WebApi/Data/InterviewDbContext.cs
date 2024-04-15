using Interview.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Interview.WebApi.Data
{
    public class InterviewDbContext : DbContext
    {
        public InterviewDbContext(DbContextOptions<InterviewDbContext> options): base(options) 
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}
