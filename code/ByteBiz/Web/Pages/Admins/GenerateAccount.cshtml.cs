using BusinessObjects.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;

namespace Web.Pages.Admins
{
    [Authorize(Roles = "Admin")]
    public class GenerateAccountModel : PageModel
    {
        private readonly IAccountRepository _aRepository;
        public GenerateAccountModel(IAccountRepository aRepository)
        {
            _aRepository = aRepository;
        }
        public async Task<IActionResult> OnGet()
        {
            Result r = await _aRepository.GenerateAccount();
            if(r.IsError)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }
    }
}
