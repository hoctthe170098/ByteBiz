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

namespace Repositories.Account
{
    public class AccountRepository : IAccountRepository
    {
		private readonly AccountDAO _accountDAO;
		private readonly IHttpContextAccessor _httpContext;
		public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContext)
		{
			_httpContext = httpContext;
			// Tạo một thể hiện của AccountDAO với UserManager và SignInManager
			_accountDAO = new AccountDAO(userManager, signInManager,_httpContext.HttpContext!.Session,httpContext);
		}
		public  async Task<Result> CreateAccount(string username, string password, string email, string phone,string RoleName)
            =>await _accountDAO.CreateAccount(username, password, email, phone, RoleName);
		public async Task<Result> Login(string username,string password)=>await _accountDAO.Login(username, password);
        public Result getListRole()=> _accountDAO.getListRole();

		public Result getRole(Guid UserId)=> _accountDAO.getRolebyUserId(UserId);

        public Result GetAccountOnSession()=>_accountDAO.GetAccountOnSession();

        public async Task<Result> GetAccountByUserId(string UserId)=>await _accountDAO.GetAccountByUserId(UserId);

        public async Task<Result> UpdateProfile(ProfileDTO profile)=>await _accountDAO.UpdateProfile(profile);

        public async Task<Result> Logout()=>await _accountDAO.Logout();

        public Task<Result> CheckExistProfileByUserId(string UserId)=>_accountDAO.CheckExistProfileByUserId(UserId);

        public async Task<Result> GetInformationFreelancerByUserId(Guid CustomerId, string Userid)=>await _accountDAO.GetInformationFreelancerByUserId(CustomerId,Userid);

        public async Task<Result> getListAccountForAdmin(string page)=>await _accountDAO.getListAccountForAdmin(page);

        public async Task<Result> GenerateAccount()=>await _accountDAO.GenerateAccount();
    }
}
