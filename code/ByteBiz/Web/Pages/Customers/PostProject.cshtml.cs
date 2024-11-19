using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;
using Repositories.CV;
using Repositories.Field;
using Repositories.Project;

namespace Web.Pages.Customers
{
    [Authorize(Roles = "Customer")]
    public class PostProjectModel : PageModel
    {
        private readonly IAccountRepository _aRepository;
        private readonly IFieldRepository _fRepository;
        private readonly IProjectRepository _pRepository;
        public List<FieldCountDTO> fields { get; set; }
        public ProjectDTO project { get; set; } = new ProjectDTO();
        public string Error { get; set; }
        public AccountDTO myAccount { get; set; }

        public PostProjectModel(IAccountRepository accountRepository, IFieldRepository fieldRepository, IProjectRepository projectRepository)
        {
            _aRepository = accountRepository;
            _fRepository = fieldRepository;
            _pRepository = projectRepository;
        }
        public async Task<IActionResult> OnGet(Guid projectId)
        {
            Result account = _aRepository.GetAccountOnSession();
            myAccount = (AccountDTO)account.Data;
            Result profile = await _aRepository.CheckExistProfileByUserId(myAccount.Id.ToString());
            if (profile.IsError)
            {
                return RedirectToPage("/Customs/Profile", new { Error = "Bạn phải cập nhật profile trước!" });
            }
            if (projectId != Guid.Empty)
            {
                Result Project = _pRepository.getProjectByProjectIdAndUserId(projectId, myAccount.Id);
                if (Project.IsError)
                {
                    return RedirectToPage("/Error");
                }
                project = (ProjectDTO)Project.Data;
            }
            Result field = _fRepository.getListField();
            if (field.IsError)
            {
                return RedirectToPage("/Error");
            }
            fields = (List<FieldCountDTO>)field.Data;
            return Page();
        }
        public async Task<IActionResult> OnPost(Guid proId, string title, Guid field, string description, string formofwork
            , int budgetfrom, int budgetto, string jobProvince, DateTime date, string selectedAddress)
        {
            Result account = _aRepository.GetAccountOnSession();
            if (account.IsError)
            {
                return RedirectToPage("/Error");
            }
            AccountDTO acc = (AccountDTO)account.Data;
            if (proId == Guid.Empty)
            {
                Result postproject = _pRepository.postProject(acc.Id, title, field, description, formofwork, budgetfrom, budgetto, (jobProvince != null) ? jobProvince : "", date);
                if (postproject.IsError)
                {
                    Error = "true";
                }
                else
                {
                    Error = "false";
                }
            }
            else
            {
                string address = "";
                if (formofwork == "Online")
                {
                    if (jobProvince == null)
                    {
                        address = selectedAddress;
                    }
                    else address = jobProvince;
                }
                else if (formofwork == "Offline")
                {
                    address = jobProvince;
                }
                Result updateproject = _pRepository.UpdateProject(acc.Id, proId, title, field, description
                    , formofwork, budgetfrom, budgetto, address, date);
                if (updateproject.IsError)
                {
                    Error = "true";
                }
                else
                {
                    Error = "false";
                }
                Result Project = _pRepository.getProjectByProjectIdAndUserId(proId, acc.Id);
                if (Project.IsError)
                {
                    return RedirectToPage("/Error");
                }
                project = (ProjectDTO)Project.Data;
            }
            Result Field = _fRepository.getListField();
            if (Field.IsError)
            {
                RedirectToPage("/Error");
            }
            fields = (List<FieldCountDTO>)Field.Data;
            return Page();
        }
    }
}
