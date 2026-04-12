using Smart_Clinic_Appointment_System_API.Model;
using Smart_Clinic_Appointment_System_API.Repository;
using System.Net.NetworkInformation;

namespace Smart_Clinic_Appointment_System_API.Service
{
    public class AppointmentService
    {
        private readonly AppointmentRespository _appointmentRespository;
        private readonly PatientRepository _patientRepository;
        private readonly DoctorRepository _doctorRepository;

        public AppointmentService(AppointmentRespository appointmentRespository, PatientRepository patientRepository, DoctorRepository doctorRepository)
        {
            _appointmentRespository = appointmentRespository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public Appointment? SaveAppointment(Appointment appointment)
        {
            Boolean isSlotAvailable;
            Patient? patient = _patientRepository.GetbyId(appointment.PatientID);
            Doctor? doctor = _doctorRepository.GetById(appointment.DoctorID);


            if (patient != null)
            {
                if (appointment.PatientID == patient.Id)
                {
                    if (doctor != null)
                    {
                        if (appointment.DoctorID == doctor.Id)
                        {
                            isSlotAvailable = CheckConflict(appointment.DoctorID, appointment.AppointmentDateTime);
                            if (isSlotAvailable)
                            {
                                appointment.Status = AppointmentStatus.Booked;
                                return _appointmentRespository.Save(appointment);
                            }
                        }
                    }

                }
            }

            return null;
        }

        public List<Appointment> GetAll(int? doctorID = null, int? PatientID = null)
        {
            return _appointmentRespository.GetAll(doctorID, PatientID);
        }

        public Appointment? GetbyID(int id)
        {
            return _appointmentRespository.GetbyID(id);
        }

        public Appointment? Delete(int id)
        {
            return _appointmentRespository.Delete(id);
        }

        public Appointment? AcceptStatus(int AppointmentID)
        {
            Appointment? appointment = GetbyID(AppointmentID);

            if(appointment == null)
            {
                return null;
            }
            if (appointment.Status != AppointmentStatus.Pending)
            {
                return null;
            }

            bool isConflict = CheckConflict(appointment.DoctorID, appointment.AppointmentDateTime);

            if(isConflict != true)
            {
                return null;

            } else
            {
                return _appointmentRespository.UpdateStatus(AppointmentID, AppointmentStatus.Booked);
                 
            }
        }

        public Appointment? RejectStatus(int AppointmentID)
        {
            Appointment? appointment = GetbyID(AppointmentID);

            if (appointment == null)
            {
                return null;
            }

            if (appointment.Status != AppointmentStatus.Pending)
            {
                return null;
            }

            return _appointmentRespository.UpdateStatus(AppointmentID, AppointmentStatus.Cancelled);

        }

        public Boolean CheckConflict(int DoctorID, DateTime dateTime)
        {
            List<Appointment> appointments = _appointmentRespository.GetAll();

            foreach (Appointment a in appointments)
            {
                if (a.DoctorID == DoctorID)
                {
                    if (a.AppointmentDateTime == dateTime)
                    {
                        return false;
                    }
                }
            }

            return true;

        }
    }
}
