using AlfredHospital.API.Models.Domain;
using System.Diagnostics.Tracing;

namespace AlfredHospital.API.Models.Domain
{
    public class Room
    {
        public Guid Id { get; set; }
        public string RoomType { get; set; }
        public long Capacity { get; set; }
        public string Status { get; set; }
        public Guid NurseId { get; set; }


        // Navigation Property
        public IEnumerable<Appointment> Appointments { get; set; }

        // Navigation Property
        public Nurse Nurse { get; set; }

    }
}
