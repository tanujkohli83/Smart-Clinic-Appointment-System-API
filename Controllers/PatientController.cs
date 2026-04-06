using Microsoft.AspNetCore.Mvc;
using Smart_Clinic_Appointment_System_API.Model;
using Smart_Clinic_Appointment_System_API.Service;

namespace Smart_Clinic_Appointment_System_API.Controllers
{
    [ApiController]
    [Route("api/Patient")]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;
        
        public PatientController(PatientService patientService) {
            _patientService = patientService;
        }

        [HttpGet("get-all")]
        public IActionResult GetAllPAtient()
        {
            List<Patient> patient = _patientService.GetAllPatient();
            return Ok(patient);
        }

    }
}
