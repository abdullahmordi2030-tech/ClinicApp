using clincApp.Models;
using Microsoft.EntityFrameworkCore;

namespace clinicApp.Models
{
    public class ClinicContext : DbContext
    
    {
        public ClinicContext(DbContextOptions<ClinicContext> options)
       : base(options)
        {
        }
        public DbSet<Bshin> Bshins { get; set; }

        public DbSet<Appintment> Appintments { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        

        public DbSet<VisitNote> VisitNotes { get; set; }





    }
}
