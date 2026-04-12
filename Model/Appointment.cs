namespace Smart_Clinic_Appointment_System_API.Model
{

    public enum AppointmentStatus
    {
        Booked,
        Completed,
        Cancelled,
        Pending
    }

    public class Appointment
    {
        public int Id { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
