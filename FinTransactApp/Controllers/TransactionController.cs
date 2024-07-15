using FinTransactApp.Models;
using FinTransactApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinTransactApp.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApiService _apiService;
         
        public TransactionController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetTransaction([FromBody] UserToken userToken)
        {
            try
            {
                var transactions = await _apiService.GetAllAsync<Transaction>("Transaction", userToken);
                return Json(transactions);
            }
            catch (Exception ex)
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
