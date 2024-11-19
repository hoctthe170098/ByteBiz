using BusinessObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Account
{
    public interface IAccountRepository
    {
        Task<Result> CreateAccount(string username, string password, string email, string phone,string RoldName);
        Task<Result> Login(string username, string password);
        Task<Result> Logout();
        Result getListRole();
        Result getRole(Guid UserId);
        Result GetAccountOnSession();
        Task<Result> GetAccountByUserId(string UserId);
        Task<Result> UpdateProfile(ProfileDTO profile);
        Task<Result> CheckExistProfileByUserId(string UserId);
        Task<Result> GetInformationFreelancerByUserId(Guid CustomerId, string Userid);
        Task<Result> getListAccountForAdmin(string page);
        Task<Result> GenerateAccount();
    }
}
