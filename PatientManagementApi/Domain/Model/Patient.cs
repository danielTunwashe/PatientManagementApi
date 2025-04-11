namespace PatientManagementApi.Domain.Model
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<PatientRecord> PatientRecords { get; set; }
    }
}
