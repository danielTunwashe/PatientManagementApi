using PatientManagementApi.Domain.Model;

namespace PatientManagementApi.Domain.DTO.PatientDto
{
    public class GetOutputDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<PatientRecord> PatientRecords { get; set; }
    }
}
