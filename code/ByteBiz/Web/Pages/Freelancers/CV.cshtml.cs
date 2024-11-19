using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;
using Repositories.CV;
using Repositories.Field;
using Repositories.Project;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.Common;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Web.Pages.Freelancers
{
    [Authorize(Roles = "Freelancer")]
    public class CVModel : PageModel
    {
        private readonly IAccountRepository _aRepository;
        private readonly ICVRepository _cRepository;
        private readonly IFieldRepository _fRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CvDTO CvDTO { get; set; }
        public List<FieldCountDTO> Fields { get; set; }
        public string error { get; set; }
        public CVModel(IHttpContextAccessor httpContext, IAccountRepository accountRepository
            , ICVRepository cVRepository, IFieldRepository fieldRepository, IWebHostEnvironment webHostEnvironment)
        {
            _httpContext = httpContext;
            _aRepository = accountRepository;
            _cRepository = cVRepository;
            _webHostEnvironment = webHostEnvironment;
            _fRepository = fieldRepository;
        }
        public async Task<IActionResult> OnGet(string Error)
        {
            Result user = _aRepository.GetAccountOnSession();
            if (user.IsError)
            {
                return RedirectToPage("/Error");
            }
            else
            {
                AccountDTO accountDTO = (AccountDTO)user.Data;
                Result field = _fRepository.getListField();
                Result cv = await _cRepository.GetCVByUserId(accountDTO.Id.ToString());
                if (field.IsError || cv.IsError)
                {
                    return RedirectToPage("/Error");
                }
                else
                {
                    error = Error;
                    Fields = (List<FieldCountDTO>)field.Data;
                    CvDTO = (CvDTO)cv.Data;
                    return Page();
                }

            }
        }
        public async Task<IActionResult> OnPost(Guid userid, IFormFile? cvupload, string usercvimg, string professionaltitle, string introdution
            , string? websiteurl, string level, Guid field, string skill)
        {
            string cvUrlUpdate = "";
            if (cvupload != null)
            {
                // Đường dẫn đến thư mục "wwwroot/avatar"
                string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "cv");
                // Kiểm tra và tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                // Tạo tên file độc nhất
                string uniqueFileName = userid.ToString() + "_" + cvupload.FileName;
                // Đường dẫn đầy đủ của file ảnh
                string filePath = Path.Combine(folderPath, uniqueFileName);
                // Lưu file ảnh vào thư mục
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await cvupload.CopyToAsync(fileStream);
                }
                cvUrlUpdate = "~/cv/" + uniqueFileName;
            }
            else
            {
                cvUrlUpdate = usercvimg;
            }
            CvDTO cv = new CvDTO()
            {
                UserId = userid,
                FieldId = field,
                Introdution = introdution,
                Level = level,
                ProfessionalTitle = professionaltitle,
                Skill = skill,
                UserCVImg = cvUrlUpdate,
                WebsiteUrl = (websiteurl != null) ? websiteurl : ""
            };
            Result updateCV = await _cRepository.UpdateCV(cv);
            if (updateCV.IsError)
            {
                return RedirectToPage("/Error");
            }
            else
            {
                Result Field = _fRepository.getListField();
                Result Cv = await _cRepository.GetCVByUserId(userid.ToString());
                if (Field.IsError || Cv.IsError)
                {
                    return RedirectToPage("/Error");
                }
                else
                {
                    Fields = (List<FieldCountDTO>)Field.Data;
                    CvDTO = (CvDTO)Cv.Data;
                    return Page();
                }
            }
        }
    }
}
