namespace PatientManagementApi.Domain.DTO.PatientRecordDto
{
    public class UpdatePatientRecordInputDto
    {
        public int Id { get; set; }

        public string IllnessDetails { get; set; }

        public string AttendeeDoctor { get; set; }

        public string Prescription { get; set; }

        public string DoctorRecommendation { get; set; }

        public int PatientId { get; set; }
    }
}
