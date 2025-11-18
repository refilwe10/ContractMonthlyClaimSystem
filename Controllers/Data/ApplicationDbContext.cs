using ContractMonthlyClaimSystem.Models;
using System.Collections.Generic;

namespace ContractMonthlyClaimSystem.Controllers.Data
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<ProgrammeCoordinator> ProgrammeCoordinators { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
