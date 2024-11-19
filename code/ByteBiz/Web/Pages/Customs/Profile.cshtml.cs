using BusinessObjects.DTO;
using BusinessObjects.Models;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;
using Repositories.Project;

namespace Web.Pages.Customs
{
    [Authorize(Roles = "Freelancer,Customer")]
    public class ProfileModel : PageModel
    {
        private readonly IAccountRepository _repository;
        private readonly IProjectRepository _pRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProfileDTO ProfileDTO { get; set; }
        public ProjectCountDTO ProjectCountDTO { get; set; }
        public string error { get; set; }
        public ProfileModel(IHttpContextAccessor httpContext, IAccountRepository repository
            , IProjectRepository projectRepository, IWebHostEnvironment webHostEnvironment)
        {
            _httpContext = httpContext;
            _repository = repository;
            _pRepository = projectRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> OnGet(string? Error)
        {
            if (Error != null)
            {
                error = Error;
            }
            Result user = _repository.GetAccountOnSession();
            if (user.IsError)
            {
                return RedirectToPage("/Error");
            }
            else
            {
                AccountDTO accountDTO = (AccountDTO)user.Data;
                Result projectCount = new Result();
                if (accountDTO.role == "Freelancer")
                {
                    projectCount = _pRepository.getProjectCountByUserId(accountDTO.Id);
                }
                else
                {
                    projectCount = _pRepository.getProjectCountByCustomerId(accountDTO.Id);
                }               
                Result profile = await _repository.GetAccountByUserId(accountDTO.Id.ToString());
                if (profile.IsError || projectCount.IsError)
                {
                    return RedirectToPage("/Error");
                }
                else
                {
                    ProjectCountDTO = (ProjectCountDTO)projectCount.Data;
                    ProfileDTO = (ProfileDTO)profile.Data;
                    return Page();
                }
            }
        }
        public async Task<IActionResult> OnPost(Guid userid, IFormFile? avatar, string fullname, string phonenumber, string email, DateTime date,
            string? skype, string address, string flink, string? olink, string identifierid, string identifiername, string avatarUrl,string role)
        {
            string avatarUrlUpdate = "";
            if (avatar != null)
            {
                // Đường dẫn đến thư mục "wwwroot/avatar"
                string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "avatar");
                // Kiểm tra và tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                // Tạo tên file độc nhất
                string uniqueFileName = userid.ToString() + "_" + avatar.FileName;
                // Đường dẫn đầy đủ của file ảnh
                string filePath = Path.Combine(folderPath, uniqueFileName);
                // Lưu file ảnh vào thư mục
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await avatar.CopyToAsync(fileStream);
                }
                avatarUrlUpdate = "~/avatar/" + uniqueFileName;
            }
            else
            {
                avatarUrlUpdate = avatarUrl;
            }
            ProfileDTO profile = new ProfileDTO()
            {
                UserId = userid,
                Address = address,
                Avatar = avatarUrlUpdate,
                Dob = date,
                Email = email,
                FacebookLink = flink,
                FullName = fullname,
                IdentifierId = identifierid,
                IdentifierName = identifiername,
                OtherLink = (olink != null) ? olink : "",
                PhoneNumber = phonenumber,
                Skype = (skype != null) ? skype : ""
            };
            Result updateProfile = await _repository.UpdateProfile(profile);
            if (updateProfile.IsError)
            {
                return RedirectToPage("/Error");
            }
            else
            {
                Result projectCount = new Result();
                if (role == "Freelancer")
                {
                    projectCount = _pRepository.getProjectCountByUserId(userid);
                }
                else
                {
                    projectCount = _pRepository.getProjectCountByCustomerId(userid);
                }
                Result Profile = await _repository.GetAccountByUserId(userid.ToString());
                if (Profile.IsError || projectCount.IsError)
                {
                    return RedirectToPage("/Error");
                }
                else
                {
                    ProjectCountDTO = (ProjectCountDTO)projectCount.Data;
                    ProfileDTO = (ProfileDTO)Profile.Data;
                    return Page();
                }
            }
        }
    }
}
