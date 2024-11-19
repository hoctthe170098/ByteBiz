using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FreelancerCvDAO
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private ISession _session;
        public FreelancerCvDAO(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, ISession session)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _session = session;
        }
        public async Task<Result> GetCvByUserId(string Userid)
        {
            Result r = new Result();
            try
            {
                var user = await _userManager.FindByIdAsync(Userid);
                if (user != null)
                {
                    using (var context = new MyDbContext())
                    {
                        var role = await _userManager.GetRolesAsync(user);
                        if (role[0] != "Freelancer")
                        {
                            r.IsError = true;
                            r.Message = "Tài khoản này không có CV!";
                        }
                        else
                        {
                            UserCV userCV = context.UserCVs.Include(u=>u.Field)
                            .FirstOrDefault(p => p.UserId == user.Id);
                            CvDTO projectDTO = new CvDTO()
                            {
                                UserId = user.Id,
                                FieldId= (userCV != null) ? userCV.FieldId :Guid.Empty,
                                FieldName = (userCV!=null)?userCV.Field.FieldName:"",
                                Introdution = (userCV != null) ? userCV.Introdution : "",
                                Level = (userCV!=null)?userCV.Level:"",
                                ProfessionalTitle = (userCV != null) ? userCV.ProfessionalTitle : "",
                                Skill = (userCV != null) ? userCV.Skill : "",
                                UserCVImg = (userCV != null) ? userCV.UserCVImg : "",
                                WebsiteUrl = (userCV != null) ? userCV.WebsiteUrl : ""
                            };
                            r.IsError = false;
                            r.Data = projectDTO;
                        }                                             
                    }
                }
                else
                {
                    r.IsError = true;
                    r.Message = "Không tìm thấy tài khoản này";                   
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
                return r;
            }
            return r;
        }
        public async Task<Result> CheckExistCvByUserId(string Userid)
        {
            Result r = new Result();
            try
            {
                var user = await _userManager.FindByIdAsync(Userid);
                if (user != null)
                {
                    using (var context = new MyDbContext())
                    {
                        UserCV cv = context.UserCVs
                            .FirstOrDefault(p => p.UserId == user.Id);
                        if (cv != null)
                        {
                            r.IsError = false;
                        }
                        else
                        {
                            r.IsError = true;
                        }
                    }
                }
                else
                {
                    r.IsError = true;
                    r.Message = "Không tìm thấy tài khoản này";
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
            }
            return r;
        }
        public async Task<Result> UpdateCV(CvDTO cv)
        {
            Result r = new Result();
            var user = await _userManager.FindByIdAsync(cv.UserId.ToString());
            if (user == null)
            {
                r.IsError = true;
                r.Message = "Không tìm thấy người dùng nào!";
            }
            else
            {
                try
                {
                    using (var context = new MyDbContext())
                    {
                        var u = context.UserCVs.FirstOrDefault(u => u.UserId == cv.UserId);
                        if (u == null)
                        {
                            UserCV userCV = new UserCV()
                            {
                                UserId = cv.UserId,
                                WebsiteUrl = cv.WebsiteUrl,
                                UserCVImg = cv.UserCVImg,
                                Skill = cv.Skill,
                                FieldId = cv.FieldId,
                                Introdution = cv.Introdution,
                                Level = cv.Level,
                                ProfessionalTitle = cv.ProfessionalTitle
                            };
                            context.UserCVs.Add(userCV);
                            context.SaveChanges();
                        }
                        else
                        {
                            u.Skill = cv.Skill;
                            u.FieldId = cv.FieldId;
                            u.Introdution = cv.Introdution;
                            u.Level = cv.Level;
                            u.ProfessionalTitle = cv.ProfessionalTitle;
                            u.WebsiteUrl = cv.WebsiteUrl;
                            u.UserCVImg = cv.UserCVImg;
                            context.SaveChanges();
                        }
                        r.IsError = false;
                        r.Data = cv;
                    }
                }
                catch (Exception e)
                {
                    r.IsError = true;
                    r.Message = e.Message;
                }
            }
            return r;
        }
    }
}
