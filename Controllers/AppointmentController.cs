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
            Appointment? a =  _appointment.SaveAppointment(appointment);
            return Ok(a);
        }

        [HttpGet("get-all")]
        public IActionResult GetAllAppointments([FromQuery] int? doctorID = null, [FromQuery] int? PatientID = null)
        {
            List<Appointment> a = _appointment.GetAll(doctorID, PatientID);
            return Ok(a);
        }

        [HttpGet("get")]
        public IActionResult GetbyID([FromHeader] int id)
        {
            Appointment? a = _appointment.GetbyID(id);
            return Ok(a);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromHeader] int id)
        {
            Appointment? a = _appointment.Delete(id);
            return Ok(a);
        }

        [HttpPut("accept-appointment")]
        public IActionResult AcceptAppointment([FromHeader] int AppointmenetID)
        {
            Appointment? a = _appointment.AcceptStatus(AppointmenetID);
            return Ok(a);
        }

        [HttpPut("reject-appointment")]
        public IActionResult RejectAppointment([FromHeader] int AppointmenetID)
        {
            return null;
        }
    }

}