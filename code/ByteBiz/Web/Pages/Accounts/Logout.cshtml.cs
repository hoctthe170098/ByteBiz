using BusinessObjects.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;

namespace Web.Pages.Accounts
{
    public class LogoutModel : PageModel
    {
        private readonly IAccountRepository _repository;
        public LogoutModel(IHttpContextAccessor httpContext, IAccountRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGet()
        {
            Result logout =  await _repository.Logout();
            if (logout.IsError)
            {
                return RedirectToPage("/Error");
            }
            else
            {
                return RedirectToPage("/Customs/Home");
            }
        }
    }
}
