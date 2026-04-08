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

        public List<Appointment> GetAll()
        {
            return appointments;
        }

        public Appointment? GetbyID(int id)
        {
            foreach(Appointment a in appointments)
            {
                if(a.Id == id)
                {
                    return a;
                }
            }
            return null;
        }

        public Appointment? Delete(int id)
        {
            foreach(Appointment a in appointments)
            {
                if(a.Id == id)
                {
                    appointments.Remove(a);
                    return a;
                }
            }
            return null;
        }

    }
}
