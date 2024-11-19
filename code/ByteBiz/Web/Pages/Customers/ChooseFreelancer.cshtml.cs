using BusinessObjects.DTO;
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
    public class ChooseFreelancerModel : PageModel
    {
        private readonly IFieldRepository _fRepository;
        private readonly IProjectRepository _pRepository;
        private readonly IAccountRepository _aRepository;
        private readonly ICVRepository _cRepository;
        private readonly IProjectBiddingRepository _bRepository;
        public ChooseFreelancerModel(IFieldRepository fRepository, IProjectRepository pRepository,
            IAccountRepository aRepository, ICVRepository cVRepository, IProjectBiddingRepository projectBiddingRepository)
        {
            _fRepository = fRepository;
            _pRepository = pRepository;
            _aRepository = aRepository;
            _cRepository = cVRepository;
            _bRepository = projectBiddingRepository;
        }
        public IActionResult OnGet(Guid ProjectId,Guid userId)
        {
            Result account = _aRepository.GetAccountOnSession();
            if(account.IsError)
            {
                return RedirectToPage("/Error");
            }
            AccountDTO accountDTO = (AccountDTO)account.Data;
            Result chooseFreelancer = _pRepository.ChooseFreelancerForProject(ProjectId, userId,accountDTO.Id);
            if (chooseFreelancer.IsError)
            {
                return RedirectToPage("/Customers/ProjectDescription", new { projectId = ProjectId, msg = "eslaf" });
            }else 
            return RedirectToPage("/Customers/ProjectDescription", new {projectId= ProjectId,msg= "eurt" });
        }
    }
}
