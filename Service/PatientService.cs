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

        public Patient GetbyID(int id)
        {
            Patient p = _patientRepo.GetbyId(id);
            return p;
        }

        public Patient? Delete(int id)
        {
            Patient p = _patientRepo.Delete(id);
            return p;
        }

        public Patient Save(Patient patient)
        {
            Patient p = _patientRepo.Save(patient);
            return p;
        }

    }
}
