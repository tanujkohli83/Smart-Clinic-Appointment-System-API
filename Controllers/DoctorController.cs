using Microsoft.AspNetCore.Mvc;
using Smart_Clinic_Appointment_System_API.Model;
using Smart_Clinic_Appointment_System_API.Service;

namespace Smart_Clinic_Appointment_System_API.Controllers
{
    [ApiController]
    [Route("api/Doctor")]
    public class DoctorController :  ControllerBase
    {

        private readonly DoctorService _doctorService;

        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }


        [HttpGet("get-all")]
        public IActionResult GetDoctors()
        {
            List<Doctor> doctors = _doctorService.GetAllDoctor();
            return Ok(doctors);
        }

        [HttpPost("save-doctor")]
        public IActionResult SaveDoctor([FromBody] Doctor doctor)
        {
            _doctorService.SaveDoctor(doctor);
            return Ok(doctor);
        }

        [HttpDelete("get-doctor")]
        public IActionResult GetById([FromHeader] int id)
        {
            Doctor d = _doctorService.GetbyId(id);
            return Ok(d);
        }

        [HttpDelete("delete-doctor")]
        public IActionResult DeleteDoctor([FromHeader] int id)
        {
            Doctor d = _doctorService.DeleteDoctor(id);
            return Ok(d);
        }
    }
}
