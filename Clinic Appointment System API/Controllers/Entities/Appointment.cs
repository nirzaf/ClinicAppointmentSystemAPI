namespace WebAPI1.Controllers.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public enum MyEnum
        {
            Scheduled,
            Confirmed,
            Cancelled,
            Completed
        } 
    }
}
