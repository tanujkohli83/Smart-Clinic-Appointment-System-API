using Smart_Clinic_Appointment_System_API.Model;

namespace Smart_Clinic_Appointment_System_API.Repository
{
    public class DoctorRepository
    {
        private readonly List<Doctor> _doctors = new List<Doctor>()
        {
            new Doctor {Id = 1, Name="Harsh", Email="Harsh@gmai.com", Specialty="Heart"}
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
