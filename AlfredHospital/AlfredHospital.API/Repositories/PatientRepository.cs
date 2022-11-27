using AlfredHospital.API.Data;
using AlfredHospital.API.Models.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AlfredHospital.API.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AlfredHospitalsDbContext alfredHospitalsDbContext;

        public PatientRepository(AlfredHospitalsDbContext alfredHospitalsDbContext)
        {
            this.alfredHospitalsDbContext = alfredHospitalsDbContext;
        }

        // create/add new patient method 
        public async Task<Patient> AddAsync(Patient patient)
        {
            patient.Id = Guid.NewGuid();
            await alfredHospitalsDbContext.AddAsync(patient);
            await alfredHospitalsDbContext.SaveChangesAsync();
            return patient;

        }

        // delete method 
        public async Task<Patient> DeleteAsync(Guid id)
        {
            var patient = await alfredHospitalsDbContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
            
            if (patient == null)
            {
                return null;
            }

            // Delete the patient

            alfredHospitalsDbContext.Patients.Remove(patient);
            await alfredHospitalsDbContext.SaveChangesAsync();
            return patient;
           
        }

        public async Task<IEnumerable<Patient>> GetAllAsync() // async and await keywords go hand in hand - making func async
        {
            return await alfredHospitalsDbContext.Patients.ToListAsync();
        }

        public async Task<Patient> GetAsync(Guid id) // finf this id and return or null 
        {
            return await alfredHospitalsDbContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<Patient> UpdateAsync(Guid id, Patient patient)
        {
            var existingPatient = await alfredHospitalsDbContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPatient == null)
            {
                return null;
            }

            existingPatient.FirstName = patient.FirstName;
            existingPatient.LastName = patient.LastName;
            existingPatient.DateOfBirth = patient.DateOfBirth;
            existingPatient.Gender = patient.Gender;
            existingPatient.Email = patient.Email;
            existingPatient.PhoneNum = patient.PhoneNum;
            existingPatient.Address = patient.Address;
            existingPatient.State = patient.State;
            existingPatient.Zip = patient.Zip;

            await alfredHospitalsDbContext.SaveChangesAsync();

            return existingPatient;

        }
    }
}
