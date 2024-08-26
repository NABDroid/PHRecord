using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PHRecord.Models.DTO;
using PHRecord.Services;

namespace PHRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalController : ControllerBase
    {
        private GlobalService globalService;

        public GlobalController(GlobalService _globalService)
        {
            globalService = _globalService;
        }

        [HttpGet]
        [Route("areaMap")]
        public async Task<ResponseDTO> areaMap()
        {
            ResponseDTO responseDTO = await globalService.allAreas();
            return responseDTO;
        }

        [HttpGet]
        [Route("allHospitals")]
        public async Task<ResponseDTO> hospitals(int divisionId, int districtId, int unionId)
        {
            ResponseDTO responseDTO = await globalService.allAreas();
            return responseDTO;
        }
    }
}
