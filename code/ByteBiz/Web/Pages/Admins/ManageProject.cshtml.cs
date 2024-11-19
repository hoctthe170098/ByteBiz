using BusinessObjects.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;
using Repositories.Field;
using Repositories.Project;

namespace Web.Pages.Admins
{
    [Authorize(Roles = "Admin")]
    public class ManageProjectModel : PageModel
    {
        private readonly IProjectRepository _pRepository;
        public ManageProjectModel(IProjectRepository projectRepository)
        {
            _pRepository = projectRepository;
        }
        public ProjectPaggingForAdminDTO Project { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public IActionResult OnGet(string statusFilter = "all", string titleSearch = "", string index="1")
        {
            Result project = _pRepository.ProjectPaggingForAdmin(statusFilter, titleSearch, index, 6);
            if(project.IsError)
            {
                return RedirectToPage("/Error");
            }
            status = statusFilter;
            title = titleSearch;    
            Project = (ProjectPaggingForAdminDTO)project.Data;
            return Page();
        }
    }
}
