using System.ComponentModel.DataAnnotations;

namespace Clinic_Appointment_System_API.Entities
{
    public class Clinic
    {
        [Key]
        public int ClinicId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Appointment Appointment { get; set; }
    }
}
