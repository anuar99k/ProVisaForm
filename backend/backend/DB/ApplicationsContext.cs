using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.DB
{
    public class ApplicationsContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Applicant> Applicants{ get; set; }
        public DbSet<Spouse> Spouses { get; set; }
        public DbSet<Child> Children { get; set; }

        public ApplicationsContext(DbContextOptions<ApplicationsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
