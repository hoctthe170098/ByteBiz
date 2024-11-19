using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;
using Repositories.CV;
using Repositories.Field;
using Repositories.Project;
using Repositories.ProjectBidding;

namespace Web.Pages.Customs
{
    [Authorize(Roles = "Freelancer,Customer")]
    public class ProjectDescriptionModel : PageModel
    {
        private readonly IFieldRepository _fRepository;
        private readonly IProjectRepository _pRepository;
        private readonly IAccountRepository _aRepository;
        private readonly ICVRepository _cRepository;
        private readonly IProjectBiddingRepository _bRepository;
        public ProjectDescriptionModel(IFieldRepository fRepository, IProjectRepository pRepository,
            IAccountRepository aRepository,ICVRepository cVRepository,IProjectBiddingRepository projectBiddingRepository)
        {
            _fRepository = fRepository;
            _pRepository = pRepository;
            _aRepository = aRepository;
            _cRepository = cVRepository;
            _bRepository = projectBiddingRepository;
        }
        public ProjectDTO project { get; set; }
        public AccountDTO account { get; set; }
        public string error { get; set; }
        public string message { get; set; }
        public IActionResult OnGet(Guid projectId)
        {
            if(projectId == Guid.Empty)
            {
                return RedirectToPage("/Error");
            }
            else
            {
                Result Project = _pRepository.getProjectById(projectId);
                Result Account = _aRepository.GetAccountOnSession();
                if(Project.IsError||Account.IsError)
                {
                    return RedirectToPage("/Error");
                }
                else
                {
                    account = (AccountDTO)Account.Data;
                    project = (ProjectDTO)Project.Data;
                    return Page();
                }
            }
        }
        public async Task<IActionResult> OnPost(Guid prjId, int bid) 
        {          
            Result Account = _aRepository.GetAccountOnSession();
            if(Account.IsError)
            {
                return RedirectToPage("/Error");
            }
            
            account = (AccountDTO)Account.Data;
            if (account.role == "Customer")
            {
                return RedirectToPage("/Error");
            }
            Result profile =await _aRepository.CheckExistProfileByUserId(account.Id.ToString());
            Result cv = await _cRepository.CheckExistCvByUserId(account.Id.ToString());
            if(profile.IsError)
            {
                return RedirectToPage("/Customs/Profile", new { Error = "Bạn phải cập nhập profile trước!" });
            }
            if(cv.IsError)
            {
                return RedirectToPage("/Freelancers/CV", new { Error = "Bạn phải cập nhật CV trước!" });
            }
            Result bidding  = _bRepository.CreateProjectBidding(prjId, account.Id,bid);
            if (bidding.IsError)
            {
                error = bidding.Message;
            }
            else
            {
                message = "Bạn đã báo giá thành công!";
            }
            Result Project = _pRepository.getProjectById(prjId);
            if (Project.IsError)
            {
                return RedirectToPage("/Error");
            }
            project = (ProjectDTO)Project.Data;
            return Page();
        }
    }
}
