# Smart Clinic Appointment System API

A robust ASP.NET Core REST API for managing clinic appointments. This system enables patients to book appointments with doctors, manage appointment statuses, and handle scheduling conflicts.

## Overview

The Smart Clinic Appointment System API provides a comprehensive solution for clinic management with features like appointment booking, status management, doctor availability checking, and appointment history tracking.

## Technology Stack

- **Framework**: ASP.NET Core (targeting .NET 10)
- **Language**: C#
- **Architecture**: Layered Architecture (Controllers → Services → Repository)
- **API Style**: RESTful API

## Project Structure

```
Smart-Clinic-Appointment-System-API/
├── Controllers/
│   └── AppointmentController.cs
├── Service/
│   └── AppointmentService.cs
├── Repository/
│   └── AppointmentRepository.cs
├── Model/
│   └── Appointment.cs
└── README.md
```

## Architecture

The project follows a three-layer architecture:

1. **Controller Layer** - Handles HTTP requests and responses
2. **Service Layer** - Contains business logic and validation
3. **Repository Layer** - Data access and storage management

## Data Models

### Appointment

```csharp
public class Appointment
{
    public int Id { get; set; }
    public int PatientID { get; set; }
    public int DoctorID { get; set; }
    public DateTime AppointmentDateTime { get; set; }
    public AppointmentStatus Status { get; set; }
}
```

### AppointmentStatus Enum

- **Booked** - Appointment is confirmed
- **Completed** - Appointment has been completed
- **Cancelled** - Appointment has been cancelled
- **Pending** - Appointment is awaiting doctor confirmation

## API Endpoints

### Create/Save Appointment

**POST** `/api/Appointment/save-appoinntment`

Request Body:
```json
{
  "patientID": 1,
  "doctorID": 1,
  "appointmentDateTime": "2025-04-20T10:00:00",
  "status": "Booked"
}
```

Response: Returns the created appointment or null if validation fails.

---

### Get All Appointments

**GET** `/api/Appointment/get-all`

Query Parameters:
- `doctorID` (optional) - Filter appointments by doctor
- `PatientID` (optional) - Filter appointments by patient

Response: Returns list of appointments based on filters.

---

### Get Appointment by ID

**GET** `/api/Appointment/get`

Header Parameters:
- `id` (required) - Appointment ID

Response: Returns a single appointment.

---

### Delete Appointment

**DELETE** `/api/Appointment/delete`

Header Parameters:
- `id` (required) - Appointment ID

Response: Returns the deleted appointment.

---

### Accept Appointment

**PUT** `/api/Appointment/accept-appointment`

Query Parameters:
- `AppointmenetID` (required) - Appointment ID to accept

Response: Updates appointment status to "Booked" if pending.

---

### Reject Appointment

**PUT** `/api/Appointment/reject-appointment`

Header Parameters:
- `AppointmenetID` (required) - Appointment ID to reject

Response: Updates appointment status to "Cancelled".

## Key Features

- **Appointment Booking**: Create new appointments with automatic validation
- **Conflict Detection**: Prevents double-booking by checking doctor availability
- **Status Management**: Track appointment lifecycle (Pending → Booked → Completed/Cancelled)
- **Filtering**: Query appointments by doctor or patient
- **Validation**: Validates patient and doctor existence before booking
- **In-Memory Storage**: Uses in-memory list for quick development and testing

## Validation Rules

When creating an appointment:
1. Patient must exist in the system
2. Doctor must exist in the system
3. Doctor must not have conflicting appointments at the same time
4. Appointment automatically set to "Booked" status upon creation

## Usage Example

```bash
# Save a new appointment
curl -X POST http://localhost:5000/api/Appointment/save-appoinntment \
  -H "Content-Type: application/json" \
  -d '{
    "patientID": 1,
    "doctorID": 1,
    "appointmentDateTime": "2025-04-20T10:00:00"
  }'

# Get all appointments
curl http://localhost:5000/api/Appointment/get-all

# Get appointments for a specific doctor
curl http://localhost:5000/api/Appointment/get-all?doctorID=1

# Get a specific appointment
curl http://localhost:5000/api/Appointment/get \
  -H "id: 1"

# Accept an appointment
curl -X PUT http://localhost:5000/api/Appointment/accept-appointment?AppointmenetID=1

# Delete an appointment
curl -X DELETE http://localhost:5000/api/Appointment/delete \
  -H "id: 1"
```

## Running the Application

1. **Clone the Repository**
   ```bash
   git clone https://github.com/tanujkohli83/Smart-Clinic-Appointment-System-API.git
   cd Smart-Clinic-Appointment-System-API
   ```

2. **Build the Project**
   ```bash
   dotnet build
   ```

3. **Run the Application**
   ```bash
   dotnet run
   ```

4. **Access the API**
   - The API will be available at `http://localhost:5000` or `https://localhost:5001`

## Future Enhancements

- Database integration (SQL Server/PostgreSQL)
- Authentication & Authorization
- Email/SMS notifications for appointments
- Doctor availability scheduling
- Patient management API
- Doctor management API
- Appointment reminders
- Payment processing
- User roles and permissions

## Dependencies

- Microsoft.AspNetCore.Http.HttpResults
- Microsoft.AspNetCore.Mvc
- .NET 10 Runtime

## Notes

- The repository currently uses in-memory storage. Data will be lost when the application restarts.
- Consider implementing a persistent database for production use.
- Some endpoint parameter passing styles (headers, query, body) may need standardization.

## License

This project is available under the MIT License.

## Contact

For issues or contributions, please visit: [GitHub Repository](https://github.com/tanujkohli83/Smart-Clinic-Appointment-System-API)
