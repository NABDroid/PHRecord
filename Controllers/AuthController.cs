using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PHRecord.Models;
using PHRecord.Models.DTO;
using PHRecord.Services;

namespace PHRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private AuthService authService;

        public AuthController(AuthService _authService)
        {
            authService = _authService;
        }

        [HttpGet]
        [Route("login")]
        public async Task<ResponseDTO> login(string userName, string password)
        {
            ResponseDTO responseDTO = await authService.login(userName, password);
            return responseDTO;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ResponseDTO> registration(UserInfo userInfo)
        {
            ResponseDTO responseDTO = await authService.register(userInfo);
            return responseDTO;
        }



    }
}
