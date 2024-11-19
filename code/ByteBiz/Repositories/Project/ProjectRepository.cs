using BusinessObjects.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Project
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly ProjectDAO _projectDAO;
        public ProjectRepository()
        {
            _projectDAO = new ProjectDAO();
        }
        public Result getListUrgenthiringProject() => _projectDAO.getListUrgenthiringProject();
        public Result getListNewHiringProject()=>_projectDAO.getListNewHiringProject();
        public Result getListSalaryProject()=>_projectDAO.getListSalaryProject();

        public Result getSearchProject(SearchProjectDTO searchModel)=>_projectDAO.getSearchProject(searchModel);

        public Result getFilterProject(int budgetFrom, int budgetTo)=>_projectDAO.getFilterProject(budgetFrom, budgetTo);

        public Result getProjectById(Guid id)=>_projectDAO.getProjectById(id);

        public Result getProjectCountByUserId(Guid userId)=>_projectDAO.getProjectCountByUserId(userId);

        public Result postProject(Guid userId, string title, Guid field, string description, string formofwork, int budgetfrom, 
            int budgetto, string jobProvince, DateTime date)
            =>_projectDAO.postProject(userId,title,field,description,formofwork,budgetfrom,budgetto,jobProvince,date);

        public Result getProjectByProjectIdAndUserId(Guid proId, Guid userId)
            =>_projectDAO.getProjectByProjectIdAndUserId(proId,userId);

        public Result UpdateProject(Guid userId, Guid proId, string title, Guid field, string description, string formofwork, int budgetfrom, int budgetto, string jobProvince, DateTime date)
            =>_projectDAO.UpdateProject(userId,proId,title,field,description,formofwork, budgetfrom,budgetto,jobProvince, date);

        public Result getProjectCountByCustomerId(Guid userId)=>_projectDAO.getProjectCountByCustomerId(userId);

        public Result UpdateStatusProjectByUserId(Guid userId) => _projectDAO.UpdateStatusProjectByUserId(userId);
        public Result ProjectPagging(Guid userId, string index, string status)=>_projectDAO.ProjectPagging(userId,index,status);

        public Result DeleteProject(Guid userId, string prjid)=>_projectDAO.DeleteProject(userId,prjid);

        public Result ProjectPaggingFreelancer(Guid userId, string index, string status)
            =>_projectDAO.ProjectPaggingFreelancer(userId,index,status);

        public Result getProjectForCustomerById(Guid userId, Guid id)=>_projectDAO.getProjectForCustomerById(userId,id);

        public Result ChooseFreelancerForProject(Guid proId, Guid FreelancerId, Guid CustomerId)
            => _projectDAO.ChooseFreelancerForProject(proId, FreelancerId, CustomerId);

        public Result ProjectPaggingForAdmin(string status, string title, string page, int pageSize)
            =>_projectDAO.ProjectPaggingForAdmin(status, title, page, pageSize);
    }
}
