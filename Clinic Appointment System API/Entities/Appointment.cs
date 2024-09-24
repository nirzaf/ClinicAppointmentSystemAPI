using System.ComponentModel.DataAnnotations;

namespace Clinic_Appointment_System_API.Entities;

public class Appointment
{
    [Key]
    public int AppointmentId { get; set; }
    [Required]
    public int PatientId { get; set; }
    //public Patient? Patient { get; set; } This property is commented out. If it were included, it would create a circular reference between Appointment and Patient. The Patient class already has a collection of Appointment objects: public virtual List<Appointment> Appointments { get; set; }
    [Required]
    public int DoctorId { get; set; }
    public required Doctor Doctor { get; set; }

    [Required]
    public int ClinicId { get; set; }
    [Required]
    public DateTime AppointmentDate { get; set; }
    [Required]
    public TimeSpan AppointmentTime { get; set; }
    [Required]
    [EnumDataType(typeof(AppointmentStatus))]
    public AppointmentStatus Status { get; set; }
    public string? Notes { get; set; }
}


public enum AppointmentStatus
{
    Scheduled,
    Confirmed,
    Cancelled,
    Completed
}
