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

        /*
        Entity Framework uses proxy classes to track changes to entities. When a navigation property is `virtual`, Entity Framework can create a proxy that intercepts changes to the property, allowing it to track changes more effectively. 
        */
        public virtual Appointment Appointment { get; set; }
    }
}
