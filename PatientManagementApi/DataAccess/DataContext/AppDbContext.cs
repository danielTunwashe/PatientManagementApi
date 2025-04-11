using Microsoft.EntityFrameworkCore;
using PatientManagementApi.Domain.Model;

namespace PatientManagementApi.DataAccess.DataContext
{
    public class AppDbContext: DbContext 
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientRecord> PatientRecords { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.PatientRecords)
                .WithOne()
                .HasForeignKey(p => p.PatientId);

            modelBuilder.Entity<PatientRecord>()
                .HasKey(pr => pr.Id);
        }
    }
}
