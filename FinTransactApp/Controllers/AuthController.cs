using FinTransactApp.Models;
using FinTransactApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinTransactApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly LoginService _loginService;

        public AuthController(LoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            try
            {
                UserToken response = await _loginService.LoginAsync(userLogin);

                if (string.IsNullOrEmpty(response.Token))
                {
                    return Unauthorized();
                }

                return Ok(new { data = response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing your request." });
            }
        }

    }
}
