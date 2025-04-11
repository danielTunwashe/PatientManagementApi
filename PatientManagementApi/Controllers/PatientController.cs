using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagementApi.Application.Services.Interface;
using PatientManagementApi.Domain.DTO.PatientDto;
using PatientManagementApi.Domain.Model;

namespace PatientManagementApi.Controllers
{
    [ApiController]
    [Route("api/Patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostPatient([FromBody] CreatePatientInputDto input)
        {
            var result  = await _patientRepository.CreatePatient(input);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatient(UpdatePatientInputDto input)
        {
            var result = await _patientRepository.UpdatePatient(input);
            return Ok(result);  
        }

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetAllPatient()
        {
            var result = await _patientRepository.GetAllPatient();
            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Patient>> GetPatientById([FromRoute] int id)
        {
            var result = await _patientRepository.GetPatientByid(id);   
            return Ok(result);
        }

        [HttpDelete("deleteById/{id}")]
        public async Task<IActionResult> DeletePatient([FromRoute] int id)
        {
            var result = await _patientRepository.DeletePatient(id);
            return Ok(result);  
        }


    }
}
