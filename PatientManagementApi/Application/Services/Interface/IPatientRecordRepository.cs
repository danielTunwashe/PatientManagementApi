using PatientManagementApi.Domain.DTO.PatientRecordDto;
using PatientManagementApi.Domain.Model;

namespace PatientManagementApi.Application.Services.Interface
{
    public interface IPatientRecordRepository
    {
        Task<string> CreatePatientRecord(CreateRecordPatientInputDto input);
        Task<string> UpdatePatientRecord(UpdatePatientRecordInputDto input);
        Task<List<PatientRecord>> GetAllPatientRecord();
        Task<List<PatientRecord>> GetSpecificPatientRecord(int id);    
        Task<PatientRecord> GetPatientRecordById(int id);
        Task<string> DeletePatientRecord(int id);

    }
}
