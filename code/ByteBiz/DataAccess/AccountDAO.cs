using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDAO
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private ISession _session;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountDAO(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, ISession session, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _session = session;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Result> CreateAccount(string username, string password, string email, string phone, string RoleName)
        {
            Result r = new Result();
            ApplicationUser u = new ApplicationUser()
            {
                UserName = username,
                Email = email,
                PhoneNumber = phone
            };
            try
            {
                var result = await _userManager.CreateAsync(u, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(u, RoleName);
                    Result login = await Login(username, password);
                    if (login.IsError)
                    {
                        r.IsError = true;
                    }
                    else
                    {
                        r.IsError = false;
                        r.Data = login.Data;
                    }
                }
                else
                {
                    r.IsError = true;
                    r.Message = "Tên đăng nhập đã tồn tại!";
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = "Có lỗi xảy ra khi tạo tài khoản, vui lòng thử lại!";
            }
            return r;
        }
        public async Task<Result> Login(string username, string password)
        {
            Result r = new Result();
            var user = await _userManager.FindByNameAsync(username);
            try
            {
                if (user != null && await _userManager.CheckPasswordAsync(user, password))
                {

                    await _signinManager.SignInAsync(user, isPersistent: false);
                    r.IsError = false;
                    r.Data = user;
                    return r;
                }
                else
                {
                    r.IsError = true;
                    r.Message = "Tên đăng nhập hoặc mật khẩu không chính xác";
                    return r;
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
                return r;
            }
        }
        public async Task<Result> Logout()
        {
            Result r = new Result();

            try
            {
                await _signinManager.SignOutAsync();
                r.IsError = false;
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
            }
            return r;
        }
        public Result getListRole()
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    List<IdentityRole<Guid>> roles = context.Roles.Where(r => r.Name != "Admin").ToList();
                    r.IsError = false;
                    r.Data = roles;
                }
                return r;
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
                return r;
            }
        }
        public Result getRolebyUserId(Guid userId)
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    IdentityUserRole<Guid> userRole = context.UserRoles.FirstOrDefault(ur => ur.UserId == userId);
                    if (userRole != null)
                    {
                        IdentityRole<Guid> role = context.Roles.Where(r => r.Id == userRole.RoleId).FirstOrDefault();
                        if (role != null)
                        {
                            r.IsError = false;
                            r.Data = role.Name;
                        }
                    }
                }
                return r;
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
                return r;
            }
        }
        public async Task<Result> getListAccountForAdmin(string page)
        {
            Result r = new Result();
            try
            {

                int index = Int32.Parse(page);
                if (index < 1)
                {
                    r.IsError = true;
                    return r;
                }
                using (var context = new MyDbContext())
                {
                    int count = _userManager.Users.Count();
                    var users = _userManager.Users
                        .Skip((index - 1) * 6)
                        .Take(6)
                        .ToList();
                    List<AccountForAdminDTO> List = new List<AccountForAdminDTO>();
                    foreach (var user in users)
                    {
                        ApplicationUserProfile profile = context.ApplicationUserProfiles
                            .Where(p => p.UserId == user.Id).FirstOrDefault();
                        var role = await _userManager.GetRolesAsync(user);
                        AccountForAdminDTO account = new AccountForAdminDTO()
                        {
                            Id = user.Id,
                            address = (profile != null) ? profile.Address : "Chưa cập nhật",
                            email = user.Email,
                            fullname = (profile != null) ? profile.FullName : "Chưa cập nhật",
                            phoneNumber = user.PhoneNumber,
                            role = role[0],
                            username = user.UserName
                        };
                        List.Add(account);
                    }
                    AccountPaggingForAdmin accountPaggingForAdmin = new AccountPaggingForAdmin()
                    {
                        listAccount = List,
                        page = index,
                        total = (count % 6 != 0) ? count / 6 + 1 : count / 6
                    };
                    r.IsError = false;
                    r.Data = accountPaggingForAdmin;
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
            }
            return r;
        }
        public async Task<Result> GetAccountByUserId(string Userid)
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
                        ApplicationUserProfile applicationUserProfile = context.ApplicationUserProfiles
                            .FirstOrDefault(p => p.UserId == user.Id);
                        ProfileDTO projectDTO = new ProfileDTO()
                        {
                            UserId = user.Id,
                            Role = role[0],
                            PhoneNumber = user.PhoneNumber,
                            Email = user.Email,
                            FacebookLink = (applicationUserProfile != null) ? applicationUserProfile.FacebookLink : "",
                            OtherLink = (applicationUserProfile != null) ? applicationUserProfile.OtherLink : "",
                            FullName = (applicationUserProfile != null) ? applicationUserProfile.FullName : "",
                            Address = (applicationUserProfile != null) ? applicationUserProfile.Address : "",
                            Avatar = (applicationUserProfile != null) ? applicationUserProfile.Avatar : "",
                            Dob = (applicationUserProfile != null) ? applicationUserProfile.Dob : DateTime.Today,
                            IdentifierId = (applicationUserProfile != null) ? applicationUserProfile.IdentifierId : "",
                            IdentifierName = (applicationUserProfile != null) ? applicationUserProfile.IdentifierName : "",
                            Skype = (applicationUserProfile != null) ? applicationUserProfile.Skype : ""
                        };
                        r.IsError = false;
                        r.Data = projectDTO;
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
        public async Task<Result> GetInformationFreelancerByUserId(Guid CustomerId, string Userid)
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
                            return r;
                        }
                        Project p = context.Projects.Where(p => p.PosterId == CustomerId
                        && p.ProjectBiddings.Select(b => b.BidderId).ToList().Contains(Guid.Parse(Userid))).FirstOrDefault();
                        if (p == null)
                        {
                            r.IsError = true;
                            return r;
                        }
                        ApplicationUserProfile applicationUserProfile = context.ApplicationUserProfiles
                            .FirstOrDefault(p => p.UserId == user.Id);
                        UserCV cv = context.UserCVs
                            .Include(c => c.Field)
                            .FirstOrDefault(p => p.UserId == user.Id);
                        FullInformationFreelancerDTO projectDTO = new FullInformationFreelancerDTO()
                        {
                            UserId = user.Id,
                            PhoneNumber = user.PhoneNumber,
                            Email = user.Email,
                            FacebookLink = applicationUserProfile.FacebookLink,
                            OtherLink = applicationUserProfile.OtherLink,
                            FullName = applicationUserProfile.FullName,
                            Address = applicationUserProfile.Address,
                            Avatar = applicationUserProfile.Avatar,
                            Dob = applicationUserProfile.Dob,
                            Skype = applicationUserProfile.Skype,
                            FieldName = cv.Field.FieldName,
                            Introdution = cv.Introdution,
                            Level = cv.Level,
                            ProfessionalTitle = cv.ProfessionalTitle,
                            Skill = cv.Skill,
                            UserCVImg = cv.UserCVImg,
                            WebsiteUrl = cv.WebsiteUrl
                        };
                        r.IsError = false;
                        r.Data = projectDTO;
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
        public async Task<Result> CheckExistProfileByUserId(string Userid)
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
                        ApplicationUserProfile applicationUserProfile = context.ApplicationUserProfiles
                            .FirstOrDefault(p => p.UserId == user.Id);
                        if (applicationUserProfile != null)
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
        public Result GetAccountOnSession()
        {
            Result r = new Result();
            try
            {
                var user = _httpContextAccessor.HttpContext.User;
                // Kiểm tra xem người dùng đã đăng nhập chưa
                if (!user.Identity.IsAuthenticated)
                {
                    r.IsError = true;
                    r.Message = "Chưa đăng nhập!";
                    return r;
                }
                else
                {
                    var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
                    var username = user.FindFirstValue(ClaimTypes.Name);
                    var role = user.FindFirstValue(ClaimTypes.Role); // Nếu bạn lưu vai trò trong Claims

                    AccountDTO accountDTO = new AccountDTO()
                    {
                        Id = Guid.Parse(userId), // Chuyển đổi ID sang Guid
                        username = username,
                        role = role,
                        fullname = "" // Nếu bạn muốn lấy fullname từ profile, bạn có thể làm thêm phần này
                    };

                    r.IsError = false;
                    r.Data = accountDTO;
                    return r;
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
                return r;
            }
        }
        public async Task<Result> UpdateProfile(ProfileDTO profile)
        {
            Result r = new Result();
            var user = await _userManager.FindByIdAsync(profile.UserId.ToString());
            if (user == null)
            {
                r.IsError = true;
                r.Message = "Không tìm thấy người dùng nào!";
            }
            else
            {
                try
                {
                    var setEmailResult = await _userManager.SetEmailAsync(user, profile.Email);
                    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, profile.PhoneNumber);
                    using (var context = new MyDbContext())
                    {
                        var p = context.ApplicationUserProfiles.FirstOrDefault(p => p.UserId == profile.UserId);
                        if (p == null)
                        {
                            ApplicationUserProfile profileUserProfile = new ApplicationUserProfile()
                            {
                                UserId = profile.UserId,
                                Address = profile.Address,
                                Avatar = profile.Avatar,
                                Dob = profile.Dob,
                                FacebookLink = profile.FacebookLink,
                                FullName = profile.FullName,
                                IdentifierId = profile.IdentifierId,
                                IdentifierName = profile.IdentifierName,
                                OtherLink = profile.OtherLink,
                                Skype = profile.Skype
                            };
                            context.ApplicationUserProfiles.Add(profileUserProfile);
                            context.SaveChanges();
                        }
                        else
                        {
                            p.OtherLink = profile.OtherLink;
                            p.Skype = profile.Skype;
                            p.IdentifierId = profile.IdentifierId;
                            p.IdentifierName = profile.IdentifierName;
                            p.Address = profile.Address;
                            p.Avatar = profile.Avatar;
                            p.Dob = profile.Dob;
                            p.FacebookLink = profile.FacebookLink;
                            p.FullName = profile.FullName;
                            context.SaveChanges();
                        }
                        r.IsError = false;
                        r.Data = profile;
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
