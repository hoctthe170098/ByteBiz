using BusinessObjects.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;

namespace Web.Pages.Accounts
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IAccountRepository _repository;
        private readonly IHttpContextAccessor _httpContext;
        public LoginModel(IHttpContextAccessor httpContext, IAccountRepository repository)
        {
            _httpContext = httpContext;
            _repository = repository;
        }
        public string username { get; set; }
        public string password { get; set; }
        public string error { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPost(string Username,string Password)
        {
            Result result = await _repository.Login(Username, Password);
            if(result.IsError)
            {
                username = Username;
                password = Password;
                error = result.Message;
                return Page();
            }
            else
            {
                return RedirectToPage("/Customs/Home");              
            }
        }
    }
}
