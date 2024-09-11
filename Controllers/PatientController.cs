using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PHRecord.Models;
using PHRecord.Models.DTO;
using PHRecord.Services;

namespace PHRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private PatientService patientService;

        public PatientController(PatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpGet]
        [Route("historyTitles")]
        public async Task<ResponseDTO> historyTitles()
        {
            ResponseDTO responseDTO = await patientService.allHistoryTitles();
            return responseDTO;
        }

        [HttpPost]
        [Route("submitPatientHistory")]
        public async Task<ResponseDTO> submitPatientHistory(List<PatientHistory> patientHistories)
        {
            ResponseDTO responseDTO = await patientService.submitHistory(patientHistories);
            return responseDTO;
        }

    }
}
