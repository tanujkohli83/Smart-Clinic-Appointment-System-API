using System.ComponentModel.DataAnnotations;

namespace Smart_Clinic_Appointment_System_API.Model
{
    public class Doctor
    {
        public int Id {  get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Specialty { get; set; } = string.Empty;

    }
}
