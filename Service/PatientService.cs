using Smart_Clinic_Appointment_System_API.Model;
using Smart_Clinic_Appointment_System_API.Repository;

namespace Smart_Clinic_Appointment_System_API.Service
{
    public class PatientService
    {
        private readonly PatientRepository _patientRepo;

        public PatientService(PatientRepository patientRepository) {
            _patientRepo = patientRepository;
        }

        public List<Patient> GetAllPatient()
        {
            return _patientRepo.GetAllPatient();
        }

    }
}
