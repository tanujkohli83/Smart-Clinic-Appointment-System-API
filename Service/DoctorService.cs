using Smart_Clinic_Appointment_System_API.Model;
using Smart_Clinic_Appointment_System_API.Repository;

namespace Smart_Clinic_Appointment_System_API.Service
{
    public class DoctorService
    {
        private readonly DoctorRepository _doctorRepository;

        public DoctorService(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public List<Doctor> GetAllDoctor()
        {
            List<Doctor> doctors = _doctorRepository.GetAllDoctors();
            return doctors;
        }

        public Doctor SaveDoctor(Doctor doctor)
        {
            return _doctorRepository.SaveDoctor(doctor);
        }

        public Doctor? GetbyId(int id)
        {
            return _doctorRepository.GetById(id);
        }

        public Doctor? DeleteDoctor(int id)
        {
            return _doctorRepository.DeleteDoctor(id);
        }

    }
}

