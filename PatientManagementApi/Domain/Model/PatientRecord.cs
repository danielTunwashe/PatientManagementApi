namespace PatientManagementApi.Domain.Model
{
    public class PatientRecord
    {
        public int Id { get; set; }

        public string IllnessDetails { get; set; }

        public string AttendeeDoctor { get; set; }

        public string Prescription { get; set; }

        public string DoctorRecommendation { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int PatientId { get; set; }
    }
}
