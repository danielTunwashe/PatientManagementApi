using Microsoft.EntityFrameworkCore;
using PatientManagementApi.Application.Services.Interface;
using PatientManagementApi.DataAccess.DataContext;
using PatientManagementApi.Domain.DTO.PatientRecordDto;
using PatientManagementApi.Domain.Model;

namespace PatientManagementApi.Application.Services.Repository
{
    public class PatientRecordRepository(AppDbContext appDbContext) : IPatientRecordRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext; // Uisng Primary Constructor
        public async Task<string> CreatePatientRecord(CreateRecordPatientInputDto input)
        {
            var patient = await _appDbContext.Patients.FirstOrDefaultAsync(x => x.Id == input.PatientId);
            if (patient == null)
            {
                throw new Exception($"Patient with Id: {input.PatientId} does not exist in the database");
            }

            var patientRecord = new PatientRecord()
            {
                IllnessDetails = input.IllnessDetails,

                AttendeeDoctor = input.AttendeeDoctor,

                Prescription = input.Prescription,

                DoctorRecommendation = input.DoctorRecommendation,

                PatientId = input.PatientId,

                CreatedAt = DateTime.Now,
            };

            await _appDbContext.PatientRecords.AddAsync(patientRecord);
            await _appDbContext.SaveChangesAsync();

            return "Patien Record Created successfully";
        }

        public async Task<string> DeletePatientRecord(int id)
        {
            var patientRecord = await _appDbContext.PatientRecords.FirstOrDefaultAsync(x => x.Id == id);
            if (patientRecord == null)
            {
                throw new Exception($"Patient with Id: {id} does not exist in the database");
            }

            _appDbContext.PatientRecords.Remove(patientRecord);

            return "PatientRecord Deleted Successfully";

        }

        public async Task<List<PatientRecord>> GetAllPatientRecord()
        {
            return await _appDbContext.PatientRecords.ToListAsync();
        }

        public async Task<PatientRecord> GetPatientRecordById(int id)
        {
            var patientRecord = await _appDbContext.PatientRecords.FirstOrDefaultAsync(x => x.Id == id);
            if (patientRecord == null)
            {
                throw new Exception($"Patient with Id: {id} does not exist in the database");
            }

            return patientRecord;
        }

        public async Task<List<PatientRecord>> GetSpecificPatientRecord(int id)
        {
            var specificPatientRecord = _appDbContext.Patients.Include(pr => pr.PatientRecords).FirstOrDefault(x => x.Id == id);
            if (specificPatientRecord == null)
            {
                throw new Exception("Record not found");
            }
            return specificPatientRecord.PatientRecords;
        }

        public async Task<string> UpdatePatientRecord(UpdatePatientRecordInputDto input)
        {
            var patientRecord = await _appDbContext.PatientRecords.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (patientRecord == null)
            {
                throw new Exception($"Patient with Id: {input.Id} does not exist in the database");
            }

            patientRecord.Id = input.Id;
            patientRecord.AttendeeDoctor = input.AttendeeDoctor;
            patientRecord.DoctorRecommendation  = input.DoctorRecommendation;
            patientRecord.PatientId = input.PatientId;
            patientRecord.UpdatedAt = DateTime.Now;
            patientRecord.IllnessDetails = input.IllnessDetails;
            patientRecord.Prescription = input.Prescription;

            _appDbContext.PatientRecords.Update(patientRecord);
            await _appDbContext.SaveChangesAsync();

            return "Patient Record Updated Successfully";
        }

       
    }
}
