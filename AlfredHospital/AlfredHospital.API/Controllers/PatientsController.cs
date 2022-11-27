using AlfredHospital.API.Models.Domain;
using AlfredHospital.API.Models.DTO;
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

        [HttpGet]

        [Route("{id:guid}")] // restricting the route to only take guid values
        [ActionName("GetPatientAsync")]
        public async Task<IActionResult> GetPatientAsync(Guid id)
        {
            var patient = await patientRepository.GetAsync(id); // domain patient

            if (patient == null)
            {
                return NotFound();
            }
            var patientDTO = mapper.Map<Models.DTO.Patient>(patient); // right - domain, Models. DTO - DTO 
            return Ok(patientDTO);
        }

        [HttpPost] // to add in database - posting

        // the incoming data is DTO - not domain 
        // create an AddPatientRequest in Models DTO

        // the function would convert DTO to Domain Model
        public async Task<IActionResult> AddPatientAsync(Models.DTO.AddPatientRequest addPatientRequest)
        {
            // request(DTO) to domain model

            var patient = new Models.Domain.Patient()
            {
                FirstName = addPatientRequest.FirstName,
                LastName = addPatientRequest.LastName,
                DateOfBirth = addPatientRequest.DateOfBirth,
                Gender = addPatientRequest.Gender,
                Email = addPatientRequest.Email,
                PhoneNum = addPatientRequest.PhoneNum,
                Address = addPatientRequest.Address,
                State = addPatientRequest.State,
                Zip = addPatientRequest.Zip,
            };

            // pass details to repo

            patient = await patientRepository.AddAsync(patient);

            // convert back to DTO 

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

            return CreatedAtAction(nameof(GetPatientAsync), new { id = patientDTO.Id }, patientDTO);// HTTP 201 - new resource was created in DB
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePatientAsync(Guid id)
        {

            // need to get patient from database

            var patient = await patientRepository.DeleteAsync(id);

            //if no patient from db
            if (patient == null)
            {
                return NotFound();
            }

            // if we found something - delete - convert to DTO model
            //var patientDTO = mapper.Map<Models.DTO.Patient>(patient); // right - domain, Models. DTO - DTO 

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

            // return back to client
            return Ok(patientDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePatientAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdatePatientRequest updatePatientRequest)
        {
            //convert DTO to domain model


            var patient = new Models.Domain.Patient()
            {
                FirstName = updatePatientRequest.FirstName,
                LastName = updatePatientRequest.LastName, 
                DateOfBirth = updatePatientRequest.DateOfBirth,
                Gender = updatePatientRequest.Gender,
                Email = updatePatientRequest.Email,
                PhoneNum = updatePatientRequest.PhoneNum,
                Address = updatePatientRequest.Address,
                State = updatePatientRequest.State,
                Zip = updatePatientRequest.Zip,
            };

            patient = await patientRepository.UpdateAsync(id, patient);

            if(patient == null)
            {
                return NotFound();
            }

            // convert back to DTO 

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

            return Ok(patientDTO);
        }
        //update region using repo
        // if Null, then Not found
        // convert domain to dto and then return 
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