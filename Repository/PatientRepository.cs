using Smart_Clinic_Appointment_System_API.Model;

namespace Smart_Clinic_Appointment_System_API.Repository
{
    public class PatientRepository
    {
        public readonly List<Patient> _patient = new List<Patient>()
        {
            new Patient{Id=1, Name= "Tanuj", Email= "tanuj@gmail.com"}
        };
        public List<Patient> GetAllPatient()
        {
            return _patient;
        }
    }
}
