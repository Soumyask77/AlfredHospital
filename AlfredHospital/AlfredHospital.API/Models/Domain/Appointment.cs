using AlfredHospital.API.Models.Domain;
using System.Diagnostics.Tracing;

namespace AlfredHospital.API.Models.Domain
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public string AppointmentDate { get; set; }
        public string Reason { get; set; }
        public Guid PatientId { get; set; }
        public Guid PhysicianId { get; set; }
        public Guid ReceptionistId { get; set; }
        public Guid RoomNum { get; set; }

        // Navigation Property
        public Patient Patient { get; set; }
        public Physician Physician { get; set; }
        public Receptionist Receptionist { get; set; }
        public Room Room { get; set; }

    }
}


