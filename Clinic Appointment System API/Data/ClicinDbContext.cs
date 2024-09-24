using Microsoft.EntityFrameworkCore;
using Clinic_Appointment_System_API.Entities;

namespace Clinic_Appointment_System_API.Data;

public class ClinicDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigurePatient(modelBuilder);
        ConfigureDoctor(modelBuilder);
        ConfigureClinic(modelBuilder);
        ConfigureAppointment(modelBuilder);
    }

    private void ConfigureAppointment(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>().HasOne(a => a.Patient);
        modelBuilder.Entity<Appointment>().HasOne(a => a.Doctor);

    }

    private void ConfigureClinic(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinic>().HasOne(a => a.Appointment);

    }

    private void ConfigureDoctor(ModelBuilder modelBuilder)
    {
    }

    private void ConfigurePatient(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>().HasOne(a => a.Appointment);
    }
}
