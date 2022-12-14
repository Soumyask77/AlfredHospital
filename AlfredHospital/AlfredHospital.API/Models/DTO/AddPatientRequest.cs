namespace AlfredHospital.API.Models.DTO
{
    public class AddPatientRequest
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
