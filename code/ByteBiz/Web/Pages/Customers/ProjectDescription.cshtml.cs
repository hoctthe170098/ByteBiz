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

namespace Web.Pages.Customers
{
    [Authorize(Roles = "Customer")]
    public class ProjectDescriptionModel : PageModel
    {
        private readonly IFieldRepository _fRepository;
        private readonly IProjectRepository _pRepository;
        private readonly IAccountRepository _aRepository;
        private readonly ICVRepository _cRepository;
        private readonly IProjectBiddingRepository _bRepository;
        public ProjectDescriptionModel(IFieldRepository fRepository, IProjectRepository pRepository,
            IAccountRepository aRepository, ICVRepository cVRepository, IProjectBiddingRepository projectBiddingRepository)
        {
            _fRepository = fRepository;
            _pRepository = pRepository;
            _aRepository = aRepository;
            _cRepository = cVRepository;
            _bRepository = projectBiddingRepository;
        }
        public ProjectForCustomerDTO project { get; set; }
        public AccountDTO account { get; set; }
        public string error { get; set; }
        public string message { get; set; }
        public IActionResult OnGet(Guid projectId, string msg)
        {
            if (projectId == Guid.Empty)
            {
                return RedirectToPage("/Error");
            }
            if (msg != null && (msg != "eurt" && msg != "eslaf"))
            {
                return RedirectToPage("/Error");
            }
            Result Account = _aRepository.GetAccountOnSession();
            if (Account.IsError)
            {
                return RedirectToPage("/Error");
            }
            else
            {
                account = (AccountDTO)Account.Data;
                Result update = _pRepository.UpdateStatusProjectByUserId(account.Id);
                if (update.IsError)
                {
                    return RedirectToPage("/Error");
                }
                Result Project = _pRepository.getProjectForCustomerById(account.Id, projectId);
                if (Project.IsError)
                {
                    return RedirectToPage("/Error");
                }
                if (msg == "eurt")
                {
                    message = "Bạn đã chọn người thành công!";
                }
                if (msg == "eslaf")
                {
                    error = "Có lỗi xảy ra, chọn người thất bại!";
                }
                project = (ProjectForCustomerDTO)Project.Data;
                return Page();
            }
        }
    }
}
