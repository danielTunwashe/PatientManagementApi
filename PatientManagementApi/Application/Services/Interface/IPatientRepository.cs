using PatientManagementApi.Domain.DTO.PatientDto;
using PatientManagementApi.Domain.Model;

namespace PatientManagementApi.Application.Services.Interface
{
    public interface IPatientRepository
    {
        Task<string> CreatePatient(CreatePatientInputDto input);

        Task<string> UpdatePatient(UpdatePatientInputDto input);

        Task<List<GetOutputDto>> GetAllPatient();

        Task<Patient> GetPatientByid(int id);

        Task<string> DeletePatient(int id); 
    }
}
