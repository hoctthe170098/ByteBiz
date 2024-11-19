using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Field;
using Repositories.Project;

namespace Web.Pages.Customs
{
    [Authorize(Roles = "Freelancer,Customer")]
    public class SearchJobModel : PageModel
    {
        private readonly IFieldRepository _fRepository;
        private readonly IProjectRepository _pRepository;
        public SearchJobModel(IFieldRepository fRepository, IProjectRepository pRepository)
        {
            _fRepository = fRepository;
            _pRepository = pRepository;
        }
        public SearchProjectDTO searchModel { get; set; } = new SearchProjectDTO();
        public List<ProjectDTO> searchProjects { get; set; }
        public List<FieldCountDTO> fields { get; set; }
        public int BudgetFrom { get; set; }
        public int BudgetTo { get; set; }
        public IActionResult OnGet(Guid? fieldId)
        {
            if(fieldId != null)
            {
                searchModel.FieldId = fieldId;
                searchModel.Address = "";
                searchModel.Title = "";
            }
            Result field = _fRepository.getListField();
            Result searchProject = _pRepository.getSearchProject(searchModel);
            if (searchProject.IsError||field.IsError)
            {
                return RedirectToPage("/Error");
            }
            else
            {
                fields = (List<FieldCountDTO>)field.Data;
                searchProjects = (List<ProjectDTO>)searchProject.Data;
                return Page();
            }
        }
        public IActionResult OnPostSearch(string title,Guid fieldId,string address)
        {
            searchModel.Title = (title!=null)?title:"";
            searchModel.FieldId = fieldId;
            searchModel.Address = (address!=null)?address:"";
            Result field = _fRepository.getListField();
            Result searchProject = _pRepository.getSearchProject(searchModel);
            if (searchProject.IsError || field.IsError)
            {
                return RedirectToPage("/Error");
            }
            else
            {
                fields = (List<FieldCountDTO>)field.Data;
                searchProjects = (List<ProjectDTO>)searchProject.Data;
                return Page();
            }
        }
        public IActionResult OnPostFilterPrice(int budgetFrom,int budgetTo)
        {
            Result field = _fRepository.getListField();
            Result searchProject = _pRepository.getFilterProject(budgetFrom,budgetTo);
            if (searchProject.IsError || field.IsError)
            {
                return RedirectToPage("/Error");
            }
            else
            {
                BudgetFrom = budgetFrom; 
                BudgetTo = budgetTo;
                fields = (List<FieldCountDTO>)field.Data;
                searchProjects = (List<ProjectDTO>)searchProject.Data;
                return Page();
            }
        }
    }
}
