using Microsoft.EntityFrameworkCore;
using JobNotesAPI.Models;

namespace JobNotesAPI.Data
{
    public class JobsDbContext : DbContext
    {
        public JobsDbContext(DbContextOptions<JobsDbContext> options) : base(options) { }

        public DbSet<JobInfo> Jobs { get; set; }
    }
}
