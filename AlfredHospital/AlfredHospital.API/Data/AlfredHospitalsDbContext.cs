using AlfredHospital.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AlfredHospital.API.Data
{
    public class AlfredHospitalsDbContext : DbContext
    {

        public AlfredHospitalsDbContext(DbContextOptions<AlfredHospitalsDbContext> options) : base(options) 
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Physician> Physicians { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
