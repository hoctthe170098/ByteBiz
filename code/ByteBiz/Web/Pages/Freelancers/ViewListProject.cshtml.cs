using BusinessObjects.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;
using Repositories.Project;

namespace Web.Pages.Freelancers
{
    [Authorize(Roles = "Freelancer")]
    public class ViewListProjectModel : PageModel
    {
        private readonly IAccountRepository _repository;
        private readonly IProjectRepository _pRepository;
        public ResultProjectPaggingFreelancerDTO projectPaggingDTO { get; set; }
        public ViewListProjectModel( IAccountRepository repository, IProjectRepository projectRepository)
        {
            _repository = repository;
            _pRepository = projectRepository;
        }
        public IActionResult OnGet(string status, string index)
        {
            if (status == null)
            {
                return RedirectToPage("/Error");
            }
            if (status != "Hiring" && status != "Done" && status != "Wating"&&status!="Refuse")
            {
                return RedirectToPage("/Error");
            }
            if (index == null)
            {
                index = "1";
            }
            Result account = _repository.GetAccountOnSession();
            if (account.IsError)
            {
                return RedirectToPage("/Error");
            }
            AccountDTO a = (AccountDTO)account.Data;
            Result projectPagging = _pRepository.ProjectPaggingFreelancer(a.Id, index, status);
            if (projectPagging.IsError)
            {
                return RedirectToPage("/Error");
            }
            projectPaggingDTO = (ResultProjectPaggingFreelancerDTO)projectPagging.Data;
            return Page();
        }
    }
}
