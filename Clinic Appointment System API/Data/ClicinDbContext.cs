using Microsoft.EntityFrameworkCore;
using Clinic_Appointment_System_API.Entities;

namespace Clinic_Appointment_System_API.Data;

// This class represents the database context for the Clinic Appointment System
public class ClinicDbContext : DbContext
{
    // Constructor that takes DbContextOptions as a parameter
    public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
    {
    }

    // DbSet properties represent tables in the database
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    // This method is called when the model for the context is being created
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure entity relationships and constraints
        ConfigurePatient(modelBuilder);
        ConfigureDoctor(modelBuilder);
        ConfigureClinic(modelBuilder);
        ConfigureAppointment(modelBuilder);
        ConfigureEmployee(modelBuilder);
    }

    // Configure the Appointment entity
    private void ConfigureAppointment(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>().HasKey(a => a.AppointmentId);
        modelBuilder.Entity<Appointment>().Property(a => a.PatientId).IsRequired();
        modelBuilder.Entity<Appointment>().Property(a => a.DoctorId).IsRequired();
        modelBuilder.Entity<Appointment>().Property(a => a.ClinicId).IsRequired();
        modelBuilder.Entity<Appointment>().Property(a => a.AppointmentDate).IsRequired();
        modelBuilder.Entity<Appointment>().Property(a => a.AppointmentTime).IsRequired();
        modelBuilder.Entity<Appointment>().Property(a => a.Status).IsRequired();
        // Define the relationship between Appointment and Doctor
        modelBuilder.Entity<Appointment>().HasOne(a => a.Doctor).WithMany().HasForeignKey(a => a.DoctorId);
    }

    // Configure the Clinic entity
    private void ConfigureClinic(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clinic>().HasKey(c => c.ClinicId);
        modelBuilder.Entity<Clinic>().Property(c => c.Name).IsRequired();
        modelBuilder.Entity<Clinic>().Property(c => c.Address).IsRequired();
        modelBuilder.Entity<Clinic>().Property(c => c.PhoneNumber).IsRequired();
        // Define the relationship between Clinic and Appointment
        modelBuilder.Entity<Clinic>().HasOne(c => c.Appointment).WithOne().HasForeignKey<Appointment>(a => a.ClinicId);
    }

    // Configure the Doctor entity
    private void ConfigureDoctor(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
        modelBuilder.Entity<Doctor>().Property(d => d.FirstName).IsRequired();
        modelBuilder.Entity<Doctor>().Property(d => d.LastName).IsRequired();
        modelBuilder.Entity<Doctor>().Property(d => d.Specialization).IsRequired();
    }

    // Configure the Patient entity
    private void ConfigurePatient(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>().HasKey(p => p.PatientId);
        modelBuilder.Entity<Patient>().Property(p => p.FirstName).HasMaxLength(255).IsRequired();
        modelBuilder.Entity<Patient>().Property(p => p.LastName).IsRequired();
        modelBuilder.Entity<Patient>().Property(p => p.DateOfBirth).IsRequired();
        modelBuilder.Entity<Patient>().Property(p => p.Gender).IsRequired();
        // Define the relationship between Patient and Appointment
        modelBuilder.Entity<Patient>().HasMany(p => p.Appointments).WithOne().HasForeignKey(a => a.PatientId);
    }

    // Configure the Employee entity
    private void ConfigureEmployee(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasKey(e => e.Id);
        modelBuilder.Entity<Employee>().Property(e => e.Name).IsRequired();
    }
}