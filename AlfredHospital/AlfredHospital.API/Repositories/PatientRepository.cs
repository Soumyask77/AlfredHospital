using AlfredHospital.API.Data;
using AlfredHospital.API.Models.Domain;
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
        public async Task<IEnumerable<Patient>> GetAllAsync() // async and await keywords go hand in hand - making func async
        {
            return await alfredHospitalsDbContext.Patients.ToListAsync();
        }
    }
}
