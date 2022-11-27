using AlfredHospital.API.Models.Domain;

namespace AlfredHospital.API.Repositories
{
    public interface IPatientRepository
    {
        // making this asynchronous code by adding the 'Task' and code after
        Task<IEnumerable<Patient>> GetAllAsync();

    }
}
