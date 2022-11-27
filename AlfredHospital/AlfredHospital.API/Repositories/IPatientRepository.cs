using AlfredHospital.API.Models.Domain;

namespace AlfredHospital.API.Repositories
{
    public interface IPatientRepository
    {
        // making this asynchronous code by adding the 'Task' and code after
        Task<IEnumerable<Patient>> GetAllAsync();


        // for CRUD operations

        Task<Patient> GetAsync(Guid id); //get single patient based on ID of patient - will return task type

        Task<Patient> AddAsync(Patient patient);

        Task<Patient> DeleteAsync(Guid id); // delete 

        Task<Patient> UpdateAsync(Guid id, Patient patient); // update 
    }
}
