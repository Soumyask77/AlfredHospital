using AutoMapper;

namespace AlfredHospital.API.Profiles
{
    public class PatientsProfile: Profile
    {
        public PatientsProfile()
        {
            CreateMap<Models.Domain.Patient, Models.DTO.Patient>()
                .ReverseMap();

            // look at the both properties and map data from source to destination
        }
    }
}
