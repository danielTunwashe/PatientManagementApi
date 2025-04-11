using Microsoft.EntityFrameworkCore;
using PatientManagementApi.Application.Services.Interface;
using PatientManagementApi.DataAccess.DataContext;
using PatientManagementApi.Domain.DTO.PatientDto;
using PatientManagementApi.Domain.Model;

namespace PatientManagementApi.Application.Services.Repository
{
    public class PatientRepository(AppDbContext appDbContext) : IPatientRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext; //using primary constructor
        public async Task<string> CreatePatient(CreatePatientInputDto input)
        {
            var patient = new Patient()
            {
                Name = input.Name,
                Address = input.Address,
            };

            await _appDbContext.Patients.AddAsync(patient);
            await _appDbContext.SaveChangesAsync();

            return "Patient Created Successfully";
        }

        public async Task<string> DeletePatient(int id)
        {
            var patient = await _appDbContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if (patient == null)
            {
                throw new Exception($"Couldnt Find Patient with Patient Id {id} in the database");
            }

            _appDbContext.Patients.Remove(patient);

            return $"Patient with Id: {id} deleted successfully";
        }

        public async Task<List<GetOutputDto>> GetAllPatient()
        {
            return await _appDbContext.Patients
                .Select(g => new GetOutputDto // Manual - Mapping the records in patient to a get output dto, since not specified in the interafce directly 
                {
                    Id = g.Id,  
                    Name = g.Name,
                    Address = g.Address,
                })   
                .ToListAsync();
        }
       

        public async Task<Patient> GetPatientByid(int id)
        {
            var patient = _appDbContext.Patients.Include(pr=>pr.PatientRecords).FirstOrDefault(x => x.Id == id);
            if(patient == null)
            {
                throw new Exception($"Patient with Id: {id} does not exist in the database");
            }

            return patient;
        }

        public async Task<string> UpdatePatient(UpdatePatientInputDto input)
        {
            var patient = _appDbContext.Patients.FirstOrDefault(x => x.Id == input.Id);
            if (patient == null)
            {
                throw new Exception($"Patient with Id: {input.Id} does not exist in the database");
            }

            patient.Name = input.Name;
            patient.Address = input.Address;

            _appDbContext.Patients.Update(patient);
            await _appDbContext.SaveChangesAsync();

            return "Recird Updated Successfully";
            
        }
    }
}
