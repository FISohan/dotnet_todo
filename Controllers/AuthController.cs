using Microsoft.AspNetCore.Mvc;
using dotnet_todo.Data;
using dotnet_todo.Dtos;
using System.Threading.Tasks;
using dotnet_todo.Model;

namespace dotnet_todo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;

        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register (UserRegistrationDto request){
            ServiceResponse<int> respone = await _authRepository.Register(new User{Username = request.username},request.password);
            if (!respone.Success)
            {
                return BadRequest(respone.Message);
            }
            return Ok(respone);
        }
        [HttpPost("Loging")]
        public async Task<IActionResult> Loging(UserLogingDto request){
            ServiceResponse<string> response = await _authRepository.Loging(request.username,request.password);
            if (response.Success == false)
            {
                return BadRequest(response.Success);
            }
            return Ok(response.Data);
        }
    }
}