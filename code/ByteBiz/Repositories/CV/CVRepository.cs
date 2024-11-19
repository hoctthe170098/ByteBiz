using BusinessObjects.DTO;
using BusinessObjects.Models;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CV
{
    public class CVRepository: ICVRepository
    {
        private readonly FreelancerCvDAO _CvDAO;
        private readonly IHttpContextAccessor _httpContext;
        public CVRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
            // Tạo một thể hiện của AccountDAO với UserManager và SignInManager
            _CvDAO = new FreelancerCvDAO(userManager, signInManager, _httpContext.HttpContext!.Session);
        }

        public async Task<Result> CheckExistCvByUserId(string Userid)=>await _CvDAO.CheckExistCvByUserId(Userid);
        public async Task<Result> GetCVByUserId(string UserId)=>await _CvDAO.GetCvByUserId(UserId);

        public async Task<Result> UpdateCV(CvDTO cvDTO)=>await _CvDAO.UpdateCV(cvDTO);
    }
}
