using Smart_Clinic_Appointment_System_API.Model;
using Smart_Clinic_Appointment_System_API.Repository;

namespace Smart_Clinic_Appointment_System_API.Service
{
    public class AppointmentService
    {
        private readonly AppointmentRespository _appointmentRespository;

        public AppointmentService(AppointmentRespository appointmentRespository)
        {
            _appointmentRespository = appointmentRespository;
        }

        public Appointment SaveAppointment(Appointment appointment)
        {
            return _appointmentRespository.Save(appointment);
        }

        public List<Appointment> GetAll()
        {
            return _appointmentRespository.GetAll();
        }
    }
}
