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
        public IActionResult GetAllPatient()
        {
            List<Patient> patient = _patientService.GetAllPatient();
            return Ok(patient);
        }

        [HttpPost("save-patient")]
        public IActionResult SavePatient([FromBody] Patient patient)
        {
            Patient p = _patientService.Save(patient);
            return Ok(p);
        }

        [HttpGet("get")]
        public IActionResult GetbyID([FromHeader] int id)
        {
            Patient p = _patientService.GetbyID(id);
            return Ok(p);
        }
        
        [HttpDelete("delete")]
        public IActionResult DeletePatient([FromHeader] int id)
        {
            Patient p = _patientService.Delete(id);
            return Ok(p);
        }

    }
}
