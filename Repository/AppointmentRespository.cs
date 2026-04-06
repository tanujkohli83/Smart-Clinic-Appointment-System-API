using Smart_Clinic_Appointment_System_API.Model;

namespace Smart_Clinic_Appointment_System_API.Repository
{
    public class AppointmentRespository
    {

        List<Appointment> appointments = new List<Appointment>();

        public Appointment Save(Appointment appointment)
        {
            appointments.Add(appointment);
            return appointment;
        }

        public void CheckConflict()
        {

        }

        public List<Appointment> GetAll()
        {
            return appointments;
        }
    }
}
