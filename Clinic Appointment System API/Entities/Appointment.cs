using System.ComponentModel.DataAnnotations;

namespace Clinic_Appointment_System_API.Entities;

public class Appointment
{
    [Key]
    public int AppointmentId { get; set; }
    [Required]
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }
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
