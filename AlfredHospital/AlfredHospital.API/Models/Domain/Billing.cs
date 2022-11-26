using System.Diagnostics.Tracing;

namespace AlfredHospital.API.Models.Domain
{
    public class Billing
    {
        public Guid Id { get; set; }
        public string BillingCounter { get; set; }
        public string BillerFirstName { get; set; }
        public string BillerLastName { get; set; }
        public string BillingDate { get; set; }
        public double BillingAmount { get; set; }
        public Guid PatientId { get; set; }

        // Navigation Property
        public Patient Patient { get; set; }
    }
}




