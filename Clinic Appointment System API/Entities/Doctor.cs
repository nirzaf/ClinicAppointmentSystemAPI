using System.ComponentModel.DataAnnotations;
namespace Clinic_Appointment_System_API.Entities
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
