using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagementApi.Application.Services.Interface;
using PatientManagementApi.Domain.DTO.PatientDto;
using PatientManagementApi.Domain.DTO.PatientRecordDto;
using PatientManagementApi.Domain.Model;

namespace PatientManagementApi.Controllers
{
    [ApiController]
    [Route("api/PatientRecord")]
    public class PatientRecordController : ControllerBase
    {
        private readonly IPatientRecordRepository _patientRecordRepository;
        public PatientRecordController(IPatientRecordRepository patientRecordRepository)
        {
            _patientRecordRepository = patientRecordRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostPatientRecord([FromBody] CreateRecordPatientInputDto input)
        {
            var result = await _patientRecordRepository.CreatePatientRecord(input);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatientRecord(UpdatePatientRecordInputDto input)
        {
            var result = await _patientRecordRepository.UpdatePatientRecord(input);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientRecord>>> GetAllPatient()
        {
            var result = await _patientRecordRepository.GetAllPatientRecord();
            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<PatientRecord>> GetPatientRecordById([FromRoute]int id)
        {
            var result = await _patientRecordRepository.GetPatientRecordById(id);
            return Ok(result);
        }

        [HttpDelete("deleteById/{id}")]
        public async Task<IActionResult> DeletePatientRecord([FromRoute] int id)
        {
            var result = await _patientRecordRepository.DeletePatientRecord(id);
            return Ok(result);
        }

        [HttpGet("GetSpecificPatientRecord/{id}")]
        public async Task<ActionResult<List<PatientRecord>>> GetSpecificPatientRecord([FromRoute] int id)
        {
            var result = await _patientRecordRepository.GetSpecificPatientRecord(id);
            return Ok(result);
        }
    }
}
