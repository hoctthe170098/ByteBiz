using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Account;
using System.Text.Json;

namespace Web.Pages.Accounts
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
		private readonly IAccountRepository _repository;
		private readonly IHttpContextAccessor _httpContext;
        public RegisterModel(IHttpContextAccessor httpContext, IAccountRepository repository)
        {
            _httpContext = httpContext;
            _repository = repository;
        }
		public List<IdentityRole<Guid>> Roles { get; set; }
        public string error { get; set; }
		public string usernameT { get; set; }
		public string emailT { get; set; }
		public string phonenumberT { get; set; }
		public string passwordT { get; set; }
        public string repassT { get; set; }
        public string roleNameT { get; set; }
        public IActionResult OnGet()
        {
            Roles = (List<IdentityRole<Guid>>)_repository.getListRole().Data;
            return Page();
        }
        public async Task<IActionResult> OnPost(string username, string email
            ,string phonenumber,string password,string repass,string roleName)
        {
            Result result = await _repository.CreateAccount(username, password, email,phonenumber , roleName); 
            if(result.IsError)
            {
                error = result.Message;
				Roles = (List<IdentityRole<Guid>>)_repository.getListRole().Data;
                usernameT = username;
                emailT = email;
                phonenumberT = phonenumber;
                passwordT = password;
                repassT = repass;
				roleNameT = roleName;
                return Page();
            }
            else
            {
                return RedirectToPage("/Customs/Home");
                }               
        }
    }
}
