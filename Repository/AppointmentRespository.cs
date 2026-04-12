using Smart_Clinic_Appointment_System_API.Model;

namespace Smart_Clinic_Appointment_System_API.Repository
{
    public class AppointmentRespository
    {

        List<Appointment> appointments = new List<Appointment>()
        {
            new Appointment { Id = 1, PatientID = 1, DoctorID = 1, AppointmentDateTime = new DateTime(2025, 4, 10, 9, 0, 0), Status = AppointmentStatus.Completed },
            new Appointment { Id = 2, PatientID = 2, DoctorID = 3, AppointmentDateTime = new DateTime(2025, 4, 11, 10, 30, 0), Status = AppointmentStatus.Completed },
            new Appointment { Id = 3, PatientID = 3, DoctorID = 2, AppointmentDateTime = new DateTime(2025, 4, 12, 11, 0, 0), Status = AppointmentStatus.Booked },
            new Appointment { Id = 4, PatientID = 4, DoctorID = 5, AppointmentDateTime = new DateTime(2025, 4, 13, 14, 0, 0), Status = AppointmentStatus.Pending },
            new Appointment { Id = 5, PatientID = 5, DoctorID = 4, AppointmentDateTime = new DateTime(2025, 4, 14, 15, 30, 0), Status = AppointmentStatus.Cancelled },
            new Appointment { Id = 6, PatientID = 1, DoctorID = 6, AppointmentDateTime = new DateTime(2025, 4, 15, 9, 30, 0), Status = AppointmentStatus.Booked },
            new Appointment { Id = 7, PatientID = 2, DoctorID = 2, AppointmentDateTime = new DateTime(2025, 4, 16, 10, 0, 0), Status = AppointmentStatus.Pending },
            new Appointment { Id = 8, PatientID = 3, DoctorID = 4, AppointmentDateTime = new DateTime(2025, 4, 17, 13, 0, 0), Status = AppointmentStatus.Booked },
            new Appointment { Id = 9, PatientID = 4, DoctorID = 1, AppointmentDateTime = new DateTime(2025, 4, 18, 11, 30, 0), Status = AppointmentStatus.Pending },
            new Appointment { Id = 10, PatientID = 5, DoctorID = 3, AppointmentDateTime = new DateTime(2025, 4, 19, 16, 0, 0), Status = AppointmentStatus.Booked }
        };


        public Appointment Save(Appointment appointment)
        {
            appointments.Add(appointment);
            return appointment;
        }

        public List<Appointment> GetAll(int? doctorID = null, int? PatientID = null)
        {
            List<Appointment> DoctorAppointment = new List<Appointment>();
            List<Appointment> PatientAppointment = new List<Appointment>();

            if (doctorID != null)
            {
                foreach (Appointment appointment in appointments)
                {
                    if (appointment.DoctorID == doctorID)
                    {
                        DoctorAppointment.Add(appointment);

                    }
                }
                return DoctorAppointment;
            }
            else if (PatientID != null)
            {
                foreach (Appointment appointment in appointments)
                {
                    if (appointment.PatientID == PatientID)
                    {
                        PatientAppointment.Add(appointment);
                    }
                }
                return PatientAppointment;
            }
            else
            {
                return appointments;
            }
        }


        public Appointment? GetbyID(int id)
        {
            foreach (Appointment a in appointments)
            {
                if (a.Id == id)
                {
                    return a;
                }
            }
            return null;
        }

        public Appointment? Delete(int id)
        {
            foreach (Appointment a in appointments)
            {
                if (a.Id == id)
                {
                    appointments.Remove(a);
                    return a;
                }
            }
            return null;
        }

        public Appointment? UpdateStatus(int AppointmentID, AppointmentStatus status)
        {


            foreach (Appointment a in appointments)
            {
                if (a.Id == AppointmentID)
                {
                    a.Status = status;
                    return a;
                }
            }

            return null;
        }

    }
}
