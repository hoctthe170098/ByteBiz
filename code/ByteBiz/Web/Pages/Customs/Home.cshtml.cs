using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;
using Repositories.Field;
using Repositories.Project;

namespace Web.Pages.Guests
{
    public class HomeModel : PageModel
    {
        private readonly IFieldRepository _fRepository;
        private readonly IProjectRepository _pRepository;
        public HomeModel(IFieldRepository fRepository,IProjectRepository pRepository)
        {
            _fRepository = fRepository;
            _pRepository = pRepository;
        }
        public List<FieldCountDTO> fields { get; set; }
        public List<ProjectDTO> projectUrgenthiringDTOs { get; set; }
        public List<ProjectDTO> projectNewHiringDTOs { get; set; }
        public List<ProjectDTO> projectGoodSalaryDTOs { get; set; }
        public IActionResult OnGet()
        {
            Result field = _fRepository.getListField();
            Result projectUrgenthiringDTO = _pRepository.getListUrgenthiringProject();
            Result projectNewHiring = _pRepository.getListNewHiringProject();
            Result projectSalary = _pRepository.getListSalaryProject();
            if (!field.IsError && !projectUrgenthiringDTO.IsError&&!projectNewHiring.IsError
                &&!projectSalary.IsError)
            {
                fields =(List<FieldCountDTO>) field.Data;
                projectUrgenthiringDTOs = (List<ProjectDTO>)projectUrgenthiringDTO.Data;
                projectNewHiringDTOs = (List<ProjectDTO>)projectNewHiring.Data;
                projectGoodSalaryDTOs = (List<ProjectDTO>)projectSalary.Data;
                return Page();
            }
            else
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
