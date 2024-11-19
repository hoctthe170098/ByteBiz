using Azure;
using BusinessObjects.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;
using Repositories.CV;
using Repositories.Project;

namespace Web.Pages.Customers
{
    [Authorize(Roles = "Customer")]
    public class DeleteProjectModel : PageModel
    {
        private readonly IAccountRepository _repository;
        private readonly IProjectRepository _pRepository;
        private readonly IHttpContextAccessor _httpContext;
        public ResultProjectPaggingDTO projectPaggingDTO { get; set; }
        public DeleteProjectModel( IAccountRepository repository, IProjectRepository projectRepository)
        {
            _repository = repository;
            _pRepository = projectRepository;
        }
        public IActionResult OnGet(string Status,string Index,string prjid)
        {
            Result account = _repository.GetAccountOnSession();
            if (account.IsError)
            {
                return RedirectToPage("/Error");
            }
            AccountDTO a = (AccountDTO)account.Data;
            Result delete = _pRepository.DeleteProject(a.Id, prjid);
            if (delete.IsError)
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Customers/ViewListProject", new { status = Status, index = Index });
        }
    }
}
