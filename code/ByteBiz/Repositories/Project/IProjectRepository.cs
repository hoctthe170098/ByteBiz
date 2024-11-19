using BusinessObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Project
{
    public interface IProjectRepository
    {
        Result getListUrgenthiringProject();
        Result getListNewHiringProject();
        Result getListSalaryProject();
        Result getSearchProject(SearchProjectDTO searchModel);
        Result getFilterProject(int budgetFrom, int budgetTo);
        public Result getProjectById(Guid id);
        public Result getProjectCountByUserId(Guid userId);
        public Result postProject(Guid userId, string title, Guid field, string description, string formofwork
            , int budgetfrom, int budgetto, string jobProvince, DateTime date);
        Result getProjectByProjectIdAndUserId(Guid proId, Guid userId);
        Result UpdateProject(Guid userId, Guid proId, string title, Guid field, string description, string formofwork
            , int budgetfrom, int budgetto, string jobProvince, DateTime date);
        Result getProjectCountByCustomerId(Guid userId);
        Result UpdateStatusProjectByUserId(Guid userId);
        Result ProjectPagging(Guid userId, string index, string status);
        Result DeleteProject(Guid userId, string prjid);
        Result ProjectPaggingFreelancer(Guid userId, string index, string status);
        Result getProjectForCustomerById(Guid userId, Guid id);
        Result ChooseFreelancerForProject(Guid proId, Guid FreelancerId, Guid CustomerId);
        Result ProjectPaggingForAdmin(string status, string title, string page, int pageSize);
    }
}
