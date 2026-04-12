using Smart_Clinic_Appointment_System_API.Model;

namespace Smart_Clinic_Appointment_System_API.Repository
{
    public class DoctorRepository
    {
        private readonly List<Doctor> _doctors = new List<Doctor>()
        {
            new Doctor {Id = 1, Name="Harsh", Email="Harsh@gmail.com", Specialty="Heart"},
            new Doctor {Id = 2, Name="Dr. Sharma", Email="sharma@gmail.com", Specialty="Orthopedics"},
            new Doctor {Id = 3, Name="Dr. Patel", Email="patel@gmail.com", Specialty="Neurology"},
            new Doctor {Id = 4, Name="Dr. Verma", Email="verma@gmail.com", Specialty="Dermatology"},
            new Doctor {Id = 5, Name="Dr. Gupta", Email="gupta@gmail.com", Specialty="Pediatrics"},
            new Doctor {Id = 6, Name="Dr. Singh", Email="singh@gmail.com", Specialty="General Medicine"}
        };

        public List<Doctor> GetAllDoctors() {
            return _doctors;
        }

        public Doctor? GetById(int id)
        {
            foreach (Doctor d in _doctors)
            {
                if(d.Id == id)
                {
                    return d;
                }
            }

            return null;
        }

        public Doctor? DeleteDoctor(int id)
        {
            foreach (Doctor d in _doctors)
            {
                if (d.Id == id)
                {
                    _doctors.Remove(d);
                    return d;
                }
            }
            return null;
        }

        public Doctor SaveDoctor(Doctor doctor)
        {
            _doctors.Add(doctor);
            return doctor;
        }
    }
}
