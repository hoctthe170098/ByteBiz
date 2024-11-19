using BusinessObjects.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;
using Repositories.CV;
using Repositories.Field;
using Repositories.Project;
using Repositories.ProjectBidding;

namespace Web.Pages.Admins
{
    [Authorize(Roles = "Admin")]
    public class ManageUserModel : PageModel
    {
        private readonly IAccountRepository _aRepository;
        public ManageUserModel(IAccountRepository aRepository)
        {
            _aRepository = aRepository;
        }
        public AccountPaggingForAdmin accountPagging { get; set; }
        public async Task<IActionResult> OnGet(string index)
        {
            if (index == null)
            {
                index = "1";
            }
            Result list =await _aRepository.getListAccountForAdmin(index);
            if(list.IsError)
            {
                return RedirectToPage("/Error");
            }
            accountPagging = (AccountPaggingForAdmin)list.Data;
            return Page();
        }
    }
}
