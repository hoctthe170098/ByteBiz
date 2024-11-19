using BusinessObjects.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;
using Repositories.Project;

namespace Web.Pages.Customers
{
    [Authorize(Roles = "Customer")]
    public class ViewInforFreelancerModel : PageModel
    {
        private readonly IAccountRepository _repository;
        private readonly IProjectRepository _pRepository;
        public FullInformationFreelancerDTO infor { get; set; }
        public string Status { get; set; }
        public ViewInforFreelancerModel(IAccountRepository repository, IProjectRepository projectRepository)
        {
            _repository = repository;
            _pRepository = projectRepository;
        }
        public async Task<IActionResult> OnGet(string status,string userId)
        {
            if (status == null)
            {
                return RedirectToPage("/Error");
            }
            if (status != "Hiring" && status != "Done" && status != "Cancel" && status != "Wating")
            {
                return RedirectToPage("/Error");
            }
            Status = status;
            Result account = _repository.GetAccountOnSession();
            AccountDTO a = (AccountDTO)account.Data;
            Result information = await _repository.GetInformationFreelancerByUserId(a.Id,userId);
            if (information.IsError)
            {
                return RedirectToPage("/Error");
            }
            infor = (FullInformationFreelancerDTO)information.Data;
            return Page();
        }
    }
}
