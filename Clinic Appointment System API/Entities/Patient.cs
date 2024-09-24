using System.ComponentModel.DataAnnotations;

namespace Clinic_Appointment_System_API.Entities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Appointment? Appointment { get; set; }
        public virtual List<Appointment> Appointments { get; set; }

    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
