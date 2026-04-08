using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Smart_Clinic_Appointment_System_API.Model;
using Smart_Clinic_Appointment_System_API.Service;

namespace Smart_Clinic_Appointment_System_API.Controllers
{
    [ApiController]
    [Route("api/Appointment")]
    public class AppointmentController : ControllerBase 
    {

        private readonly AppointmentService _appointment;

        public AppointmentController(AppointmentService appointment)
        {
            _appointment = appointment;
        }

        [HttpPost("save-appoinntment")]
        public IActionResult SaveAppointment([FromBody] Appointment appointment)
        {
            Appointment a =  _appointment.SaveAppointment(appointment);
            return Ok(a);
        }

        [HttpGet("get-all")]
        public IActionResult GetAllAppointments()
        {
            List<Appointment> a = _appointment.GetAll();
            return Ok(a);
        }

        [HttpGet("get")]
        public IActionResult GetbyID([FromHeader] int id)
        {
            Appointment a = _appointment.GetbyID(id);
            return Ok(a);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromHeader] int id)
        {
            Appointment a = _appointment.Delete(id);
            return Ok(a);
        }
    }
}