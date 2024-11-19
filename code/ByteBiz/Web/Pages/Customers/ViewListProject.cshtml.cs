using BusinessObjects.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;
using Repositories.Project;

namespace Web.Pages.Customers
{
    [Authorize(Roles = "Customer")]
    public class ViewListProjectModel : PageModel
    {
        private readonly IAccountRepository _repository;
        private readonly IProjectRepository _pRepository;
        private readonly IHttpContextAccessor _httpContext;
        public ResultProjectPaggingDTO projectPaggingDTO { get; set; }
        public ViewListProjectModel(IHttpContextAccessor httpContext, IAccountRepository repository
            , IProjectRepository projectRepository)
        {
            _httpContext = httpContext;
            _repository = repository;
            _pRepository = projectRepository;
        }
        public IActionResult OnGet(string status,string index)
        {
            if (status == null)
            {
                return RedirectToPage("/Error");
            }
            if (status != "Hiring" && status != "Done" && status != "Cancel"&&status!="Wating")
            {
                return RedirectToPage("/Error");
            }
            if(index == null)
            {
                index = "1";
            }
            Result account = _repository.GetAccountOnSession();
            if (account.IsError)
            {
                return RedirectToPage("/Error");
            }
            AccountDTO a = (AccountDTO)account.Data;
            Result update = _pRepository.UpdateStatusProjectByUserId(a.Id);
            if(update.IsError)
            {
                return RedirectToPage("/Error");
            }
            Result projectPagging = _pRepository.ProjectPagging(a.Id,index,status);
            if (projectPagging.IsError)
            {
                return RedirectToPage("/Error");
            }
            projectPaggingDTO = (ResultProjectPaggingDTO)projectPagging.Data;
            return Page();
        }
    }
}
