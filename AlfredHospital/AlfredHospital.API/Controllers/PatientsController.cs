using AlfredHospital.API.Models.Domain;
using AlfredHospital.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlfredHospital.API.Controllers
{
    [ApiController]
    [Route("[controller]")] // end point to controller
    public class PatientsController : Controller
    {
        private readonly IPatientRepository patientRepository;
        private readonly IMapper mapper;
        public PatientsController(IPatientRepository patientRepository, IMapper mapper) 
        {
            this.patientRepository = patientRepository;
            this.mapper = mapper;
           
        }

      

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await patientRepository.GetAllAsync(); // because Async method, need to use await keywork, then need to use func async by adding async keywork and Task

            // Patients DTO Return DTO
            // Commenting all this out for reference, using Automapper now - 
            /* var patientsDTO = new List<Models.DTO.Patient>();

             patients.ToList().ForEach(patient =>
             {
                 var patientDTO = new Models.DTO.Patient()
                 {
                     Id = patient.Id,
                     FirstName = patient.FirstName,
                     LastName = patient.LastName,
                     DateOfBirth = patient.DateOfBirth,
                     Gender = patient.Gender,
                     Email = patient.Email,
                     PhoneNum = patient.PhoneNum,
                     Address = patient.Address,
                     State = patient.State,
                     Zip = patient.Zip,
                 };

                 patientsDTO.Add(patientDTO);
             }); */

            var patientsDTO = mapper.Map<List<Models.DTO.Patient>>(patients);

            return Ok(patientsDTO);
        }
        
    }
}


// this is a static list - not using anymore 

/* var patients = new List<Patient>()
            {
                new Patient()
                {

                    Id = Guid.NewGuid(),
                    FirstName = "Logan",
                    LastName = "Klein",
                    DateOfBirth = "05/17/2001",
                    Gender = "Male",
                    Email = "kleinlp@alfredstate.edu",
                    Address = "73 Osborne Hill, Fishkill",
                    State = "NY",
                    Zip = "12590"
                },

                new Patient()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Soumya",
                    LastName = "Konar",
                    DateOfBirth = "10/19/2002",
                    Gender = "Female",
                    Email = "konarss@alfredstate.edu",
                    Address = "10 Upper College Dr",
                    State = "NY",
                    Zip = "14802"
                }
            };
            */