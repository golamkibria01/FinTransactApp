using FinTransactApp.Models;
using FinTransactApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinTransactApp.Controllers
{
    public class AccountInformationController : Controller
    {
        private readonly ApiService _apiService;

        public AccountInformationController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
         
        [HttpPost]
        public async Task<JsonResult> GetAccountInformation([FromBody] UserToken userToken)
        {
            try
            {
                var accountInformation = await _apiService.GetAllAsync<AccountInformation>("AccountInformation", userToken);
                return Json(accountInformation);
            }
            catch(Exception ex) 
            {
                var errorResponse = new
                {
                    Status = "Error",
                    Message = "An error occurred while fetching account information.",
                    Details = ex.Message 
                };
                return new JsonResult(errorResponse) { StatusCode = 500 };
            }           
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

    }
}
 