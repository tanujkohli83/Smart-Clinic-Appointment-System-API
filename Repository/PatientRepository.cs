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

        public Patient Save(Patient patient)
        {
            _patient.Add(patient);
            return patient;
        }

        public Patient? Delete(int id)
        {
            foreach(Patient p in _patient)
            {
                if(p.Id == id)
                {
                    _patient.Remove(p);
                    return p;
                }
            }
            return null;
        }

        public Patient? GetbyId(int id)
        {
            foreach (Patient p in _patient)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
