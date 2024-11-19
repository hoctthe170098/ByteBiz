using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class ProjectDAO
    {
        public Result getListUrgenthiringProject()
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    List<Project> projects = context.Projects.Where(p => p.Status == "Hiring"
                    && p.EndDate >= DateTime.Today).Include(p => p.Field).Include(p => p.PosterUser).ThenInclude(u => u.ApplicationUserProfile)
                        .OrderBy(p => p.EndDate)
                        .Take(6)
                        .ToList();
                    List<ProjectDTO> projectDTOs = new List<ProjectDTO>();
                    foreach (var item in projects)
                    {
                        int count = context.ProjectBiddings.Where(p => p.ProjectId == item.ProjectId).Count();
                        ProjectDTO projectDTO = new ProjectDTO()
                        {
                            Id = item.ProjectId,
                            avatarPoster = item.PosterUser.ApplicationUserProfile.Avatar,
                            namePoster = item.PosterUser.ApplicationUserProfile.FullName,
                            Address = (item.Address != "") ? item.Address : "Không có",
                            FormOfWork = item.FormOfWork,
                            BiddingCount = count,
                            BudgetFrom = item.BudgetFrom,
                            BudgetTo = item.BudgetTo,
                            Description = item.Description,
                            EndDate = item.EndDate,
                            FieldName = item.Field.FieldName,
                            Title = item.Title
                        };
                        projectDTOs.Add(projectDTO);
                    }
                    r.IsError = false;
                    r.Data = projectDTOs;
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
        public Result getListNewHiringProject()
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    List<Project> projects = context.Projects.Where(p => p.Status == "Hiring")
                        .Include(p => p.Field).Include(p => p.PosterUser).ThenInclude(u => u.ApplicationUserProfile)
                        .OrderByDescending(p => p.CreatedDate)
                        .Take(12)
                        .ToList();
                    List<ProjectDTO> projectDTOs = new List<ProjectDTO>();
                    foreach (var item in projects)
                    {
                        int count = context.ProjectBiddings.Where(p => p.ProjectId == item.ProjectId).Count();
                        ProjectDTO projectDTO = new ProjectDTO()
                        {
                            Id = item.ProjectId,
                            avatarPoster = item.PosterUser.ApplicationUserProfile.Avatar,
                            namePoster = item.PosterUser.ApplicationUserProfile.FullName,
                            Address = (item.Address != "") ? item.Address : "Không có",
                            FormOfWork = item.FormOfWork,
                            BiddingCount = count,
                            BudgetFrom = item.BudgetFrom,
                            BudgetTo = item.BudgetTo,
                            Description = item.Description,
                            EndDate = item.EndDate,
                            FieldName = item.Field.FieldName,
                            Title = item.Title
                        };
                        projectDTOs.Add(projectDTO);
                    }
                    r.IsError = false;
                    r.Data = projectDTOs;
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
        public Result getListSalaryProject()
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    List<Project> projects = context.Projects.Where(p => p.Status == "Hiring")
                        .Include(p => p.Field).Include(p => p.PosterUser).ThenInclude(u => u.ApplicationUserProfile)
                        .OrderByDescending(p => p.BudgetTo)
                        .Take(12)
                        .ToList();
                    List<ProjectDTO> projectDTOs = new List<ProjectDTO>();
                    foreach (var item in projects)
                    {
                        int count = context.ProjectBiddings.Where(p => p.ProjectId == item.ProjectId).Count();
                        ProjectDTO projectDTO = new ProjectDTO()
                        {
                            Id = item.ProjectId,
                            avatarPoster = item.PosterUser.ApplicationUserProfile.Avatar,
                            namePoster = item.PosterUser.ApplicationUserProfile.FullName,
                            Address = (item.Address != "") ? item.Address : "Không có",
                            FormOfWork = item.FormOfWork,
                            BiddingCount = count,
                            BudgetFrom = item.BudgetFrom,
                            BudgetTo = item.BudgetTo,
                            Description = item.Description,
                            EndDate = item.EndDate,
                            FieldName = item.Field.FieldName,
                            Title = item.Title
                        };
                        projectDTOs.Add(projectDTO);
                    }
                    r.IsError = false;
                    r.Data = projectDTOs;
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
        public Result getSearchProject(SearchProjectDTO searchModel)
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    List<Project> projects = new List<Project>();
                    if (searchModel.FieldId == null || searchModel.FieldId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                    {
                        projects = context.Projects
                            .Where(p => p.Status == "Hiring"
                        && p.Title.Contains(searchModel.Title)
                        && p.Address.Contains(searchModel.Address))
                            .Include(p => p.Field).Include(p => p.PosterUser).ThenInclude(u => u.ApplicationUserProfile)
                            .ToList();
                    }
                    else
                    {
                        projects = context.Projects.Where(p => p.Status == "Hiring"
                        && p.Title.Contains(searchModel.Title)
                        && p.Address.Contains(searchModel.Address) && p.FieldId == searchModel.FieldId)
                            .Include(p => p.Field).Include(p => p.PosterUser).ThenInclude(u => u.ApplicationUserProfile)
                            .ToList();
                    }
                    List<ProjectDTO> projectDTOs = new List<ProjectDTO>();
                    foreach (var item in projects)
                    {
                        int count = context.ProjectBiddings.Where(p => p.ProjectId == item.ProjectId).Count();
                        ProjectDTO projectDTO = new ProjectDTO()
                        {
                            Id = item.ProjectId,
                            avatarPoster = item.PosterUser.ApplicationUserProfile.Avatar,
                            namePoster = item.PosterUser.ApplicationUserProfile.FullName,
                            Address = (item.Address != "") ? item.Address : "Không có",
                            FormOfWork = item.FormOfWork,
                            BiddingCount = count,
                            BudgetFrom = item.BudgetFrom,
                            BudgetTo = item.BudgetTo,
                            Description = item.Description,
                            EndDate = item.EndDate,
                            FieldName = item.Field.FieldName,
                            Title = item.Title
                        };
                        projectDTOs.Add(projectDTO);
                    }
                    r.IsError = false;
                    r.Data = projectDTOs;
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
        public Result getFilterProject(int budgetFrom, int budgetTo)
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    List<Project> projects = new List<Project>();
                    projects = context.Projects.Where(p => p.Status == "Hiring" && p.BudgetFrom >= budgetFrom && p.BudgetTo <= budgetTo)
                        .Include(p => p.Field).Include(p => p.Field).Include(p => p.PosterUser).ThenInclude(u => u.ApplicationUserProfile)
                        .ToList();
                    List<ProjectDTO> projectDTOs = new List<ProjectDTO>();
                    foreach (var item in projects)
                    {
                        int count = context.ProjectBiddings.Where(p => p.ProjectId == item.ProjectId).Count();
                        ProjectDTO projectDTO = new ProjectDTO()
                        {
                            Id = item.ProjectId,
                            avatarPoster = item.PosterUser.ApplicationUserProfile.Avatar,
                            namePoster = item.PosterUser.ApplicationUserProfile.FullName,
                            Address = (item.Address != "") ? item.Address : "Không có",
                            FormOfWork = item.FormOfWork,
                            BiddingCount = count,
                            BudgetFrom = item.BudgetFrom,
                            BudgetTo = item.BudgetTo,
                            Description = item.Description,
                            EndDate = item.EndDate,
                            FieldName = item.Field.FieldName,
                            Title = item.Title
                        };
                        projectDTOs.Add(projectDTO);
                    }
                    r.IsError = false;
                    r.Data = projectDTOs;
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
        public Result getProjectById(Guid id)
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    Project project = new Project();
                    project = context.Projects.Where( p=>p.ProjectId == id)
                        .Include(p => p.Field).Include(p => p.PosterUser).ThenInclude(u => u.ApplicationUserProfile)
                        .FirstOrDefault();
                    if (project != null)
                    {
                        if (project.EndDate < DateTime.Now&&project.Status=="Hiring")
                        {
                            project.Status = "Wating";
                            context.SaveChanges();
                        }
                        int count = context.ProjectBiddings.Where(p => p.ProjectId == project.ProjectId).Count();
                        ProjectDTO projectDTO = new ProjectDTO()
                        {
                            Id = project.ProjectId,
                            avatarPoster = project.PosterUser.ApplicationUserProfile.Avatar,
                            namePoster = project.PosterUser.ApplicationUserProfile.FullName,
                            Address = (project.Address != "") ? project.Address : "Không có",
                            FormOfWork = project.FormOfWork,
                            BiddingCount = count,
                            BudgetFrom = project.BudgetFrom,
                            BudgetTo = project.BudgetTo,
                            Description = project.Description,
                            EndDate = project.EndDate,
                            FieldName = project.Field.FieldName,
                            Title = project.Title
                        };
                        r.IsError = false;
                        r.Data = projectDTO;
                        return r;
                    }
                    else
                    {
                        r.IsError = true;
                        r.Message = "Không tìm thấy project!";
                        return r;
                    }
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
                return r;
            }
        }
        public Result getProjectForCustomerById(Guid userId,Guid id)
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    Project project = new Project();
                    project = context.Projects.Where(p=>p.PosterId==userId&&p.ProjectId == id)
                        .Include(p => p.Field)
                        .FirstOrDefault();
                    if (project != null)
                    {
                        List<ProjectBidding> projectBidding = context.ProjectBiddings
                            .Where(p=>p.ProjectId==project.ProjectId)
                            .Include(p=>p.Bidder)
                            .ThenInclude(b=>b.ApplicationUserProfile)
                            .ToList();
                        ProjectForCustomerDTO projectDTO = new ProjectForCustomerDTO()
                        {
                            Id= project.ProjectId,
                            Address = project.Address,
                            Description = project.Description,
                            BudgetFrom = project.BudgetFrom,
                            BudgetTo = project.BudgetTo,
                            EndDate = project.EndDate,
                            FieldName = project.Field.FieldName,
                            FormOfWork = project.FormOfWork,
                            Status = project.Status,
                            Title = project.Title,
                            BiddingCount = projectBidding.Count
                        };
                        List<ShortInfoFreelancerDTO> ShortInfoFreelancerDTOList = new List<ShortInfoFreelancerDTO>();
                        foreach (var item in projectBidding)
                        {
                            ShortInfoFreelancerDTO shortInfoFreelancerDTO = new ShortInfoFreelancerDTO()
                            {
                                BidMoney = item.MoneyBidding,
                                Id = item.BidderId,
                                Name = item.Bidder.ApplicationUserProfile.FullName
                            };
                            ShortInfoFreelancerDTOList.Add(shortInfoFreelancerDTO);

                            projectDTO.shortProfileFreelancers = ShortInfoFreelancerDTOList;
                        }
                        r.IsError = false;
                        r.Data = projectDTO;
                        return r;
                    }
                    else
                    {
                        r.IsError = true;
                        r.Message = "Không tìm thấy project!";
                        return r;
                    }
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
                return r;
            }
        }
        public Result getProjectByProjectIdAndUserId(Guid proId, Guid userId)
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    Project project = new Project();
                    project = context.Projects.Where(p => p.Status == "Hiring" && p.ProjectId == proId
                    && p.PosterId == userId)
                        .Include(p => p.Field).Include(p => p.Field).Include(p => p.PosterUser)
                        .ThenInclude(u => u.ApplicationUserProfile)
                        .FirstOrDefault();
                    if (project != null)
                    {
                        int count = context.ProjectBiddings.Where(p => p.ProjectId == project.ProjectId).Count();
                        ProjectDTO projectDTO = new ProjectDTO()
                        {
                            Id = project.ProjectId,
                            avatarPoster = project.PosterUser.ApplicationUserProfile.Avatar,
                            namePoster = project.PosterUser.ApplicationUserProfile.FullName,
                            Address = (project.Address != "") ? project.Address : "Không có",
                            FormOfWork = project.FormOfWork,
                            BiddingCount = count,
                            BudgetFrom = project.BudgetFrom,
                            BudgetTo = project.BudgetTo,
                            Description = project.Description,
                            EndDate = project.EndDate,
                            FieldName = project.Field.FieldName,
                            Title = project.Title
                        };
                        r.IsError = false;
                        r.Data = projectDTO;
                    }
                    else
                    {
                        r.IsError = true;
                        r.Message = "Không tìm thấy project!";
                    }
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
            }
            return r;
        }
        public Result getProjectCountByUserId(Guid userId)
        {
            Result r = new Result();
            ProjectCountDTO projectCountDTO = new ProjectCountDTO();
            try
            {
                using (var context = new MyDbContext())
                {
                    projectCountDTO.ProjectBidding = context.ProjectBiddings.Where(p => p.Project.Status == "Hiring"
                    && p.BidderId == userId).Count();
                    projectCountDTO.ProjectWaiting = context.ProjectBiddings.Where(p => p.BidderId == userId &&
                    p.Project.Status == "Done" && p.Project.ReceiverId == null).Count();
                    projectCountDTO.ProjectDone = context.Projects.Where(p => p.ReceiverId == userId && p.Status == "Done").Count();
                    projectCountDTO.ProjectCancel = context.Projects.Where(p => p.PosterId == userId && p.Status == "Cancel").Count();
                    r.IsError = false;
                    r.Data = projectCountDTO;
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
        public Result getProjectCountByCustomerId(Guid userId)
        {
            Result r = new Result();
            ProjectCountDTO projectCountDTO = new ProjectCountDTO();
            try
            {
                using (var context = new MyDbContext())
                {
                    projectCountDTO.ProjectBidding = context.Projects.Where(p => p.Status == "Hiring"
                    && p.PosterId == userId).Count();
                    projectCountDTO.ProjectWaiting = context.Projects.Where(p => p.Status == "Done" && p.PosterId == userId
                    && p.ReceiverId == null).Count();
                    projectCountDTO.ProjectDone = context.Projects.Where(p => p.PosterId == userId && p.Status == "Done"
                    && p.ReceiverId != null).Count();
                    projectCountDTO.ProjectCancel = context.Projects.Where(p => p.PosterId == userId && p.Status == "Cancel").Count();
                    r.IsError = false;
                    r.Data = projectCountDTO;
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
        public Result postProject(Guid userId, string title, Guid field, string description, string formofwork
            , int budgetfrom, int budgetto, string jobProvince, DateTime date)
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    Project p = new Project()
                    {
                        ProjectId = new Guid(),
                        CreatedDate = DateTime.Now,
                        EndDate = date,
                        Address = jobProvince,
                        BudgetFrom = budgetfrom,
                        BudgetTo = budgetto,
                        FormOfWork = formofwork,
                        Status = "Hiring",
                        PosterId = userId,
                        FieldId = field,
                        Description = description,
                        Title = title
                    };
                    context.Projects.Add(p);
                    context.SaveChanges();
                    r.IsError = false;
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
            }
            return r;
        }
        public Result UpdateProject(Guid userId, Guid proId, string title, Guid field, string description, string formofwork
            , int budgetfrom, int budgetto, string jobProvince, DateTime date)
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    Project p = context.Projects.Where(p => p.PosterId == userId && p.ProjectId == proId).FirstOrDefault();
                    if (p != null)
                    {
                        p.EndDate = date;
                        p.Address = jobProvince;
                        p.BudgetFrom = budgetfrom;
                        p.BudgetTo = budgetto;
                        p.FormOfWork = formofwork;
                        p.Status = "Hiring";
                        p.FieldId = field;
                        p.Description = description;
                        p.Title = title;
                        context.SaveChanges();
                        r.IsError = false;
                    }
                    else
                    {
                        r.IsError = true;
                    }
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
            }
            return r;
        }
        public Result UpdateStatusProjectByUserId(Guid userId)
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    List<Project> projects = context.Projects.Where(p => p.PosterId == userId && p.Status != "Cancel").ToList();
                    foreach (var item in projects)
                    {
                        if (item.Status == "Hiring" && item.EndDate < DateTime.Now)
                        {
                            item.Status = "Wating";
                            context.SaveChanges();
                        }
                        else if (item.Status == "Wating" && (DateTime.Now - item.EndDate).Days > 10)
                        {
                            item.Status = "Cancel";
                            context.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
            }
            return r;
        }
        public Result ChooseFreelancerForProject(Guid proId,Guid FreelancerId,Guid CustomerId)
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    Project project = context.Projects.FirstOrDefault(p => p.ProjectId == proId
                    && p.PosterId == CustomerId && p.Status == "Wating"
                    &&p.ReceiverId==null
                    &&context.ProjectBiddings.FirstOrDefault(b=>b.ProjectId==proId&&b.BidderId==FreelancerId)!=null
                    );
                    if(project == null)
                    {
                        r.IsError = true;
                    }
                    else
                    {
                        project.ReceiverId = FreelancerId;
                        project.Status = "Done";
                        context.SaveChanges();
                        r.IsError = false;
                    }
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
            }
            return r;
        }
        public Result ProjectPagging(Guid userId, string index, string status)
        {
            Result r = new Result();
            try
            {
                int page = Int32.Parse(index);
                if (page < 1)
                {
                    r.IsError = true;
                    return r;
                }
                using (var context = new MyDbContext())
                {
                    int count = context.Projects.Where(p => p.PosterId == userId && p.Status == status).Count();
                    List<Project> projects = context.Projects.Where(p => p.PosterId == userId && p.Status == status)
                        .Include(p => p.ReceiverUser)
                        .ThenInclude(u => u.ApplicationUserProfile)
                        .Skip((page - 1) * 6).Take(6)
                        .OrderBy(p => p.EndDate)
                        .ToList();
                    List<ProjectPaggingDTO> projectPaggings = new List<ProjectPaggingDTO>();
                    foreach (var item in projects)
                    {
                        ProjectPaggingDTO p = new ProjectPaggingDTO()
                        {
                            Id = item.ProjectId,
                            BiddingCount = context.ProjectBiddings.Where(p => p.ProjectId == item.ProjectId).Count(),
                            EndDate = item.EndDate,
                            ReceiverId = item.ReceiverId,
                            ReceiverName = (item.ReceiverUser != null) ? item.ReceiverUser.ApplicationUserProfile.FullName : "Chưa có người nhận",
                            Title = item.Title
                        };
                        projectPaggings.Add(p);
                    }
                    ResultProjectPaggingDTO result = new ResultProjectPaggingDTO()
                    {
                        page = page,
                        projects = projectPaggings,
                        StatusProject = status,
                        total = (count % 6 != 0) ? (count / 6 + 1) : (count / 6)
                    };
                    r.IsError = false;
                    r.Data = result;
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
            }
            return r;
        }
        public Result ProjectPaggingForAdmin(string status, string title, string page, int pageSize)
        {
            Result r = new Result();
            ProjectPaggingForAdminDTO projectPagging = new ProjectPaggingForAdminDTO();
            try
            {
                int pag = Int32.Parse(page);
                if (pag < 1)
                {
                    r.IsError = true; 
                    return r;
                }
                using (var context = new MyDbContext())
                {
                    var query = context.Projects.AsQueryable();

                    if (!string.IsNullOrEmpty(title))
                    {
                        query = query.Where(p => p.Title.Contains(title));
                    }

                    if (status != "all")
                    {
                        query = query.Where(p => p.Status == status);
                    }
                    projectPagging.TotalPages = (int)Math.Ceiling((double)query.Count() / pageSize);
                    projectPagging.CurrentPage = pag;
                    var project =   query
                        .Include(p=>p.ReceiverUser)
                        .ThenInclude(r=>r.ApplicationUserProfile)
                        .Include(p=>p.PosterUser)
                        .ThenInclude(p=>p.ApplicationUserProfile)
                        .Skip((pag - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                    List<ProjectForAdminDTO> ProjectForAdminDTO = new List<ProjectForAdminDTO>();
                    foreach(var item in project)
                    {
                        ProjectForAdminDTO p = new ProjectForAdminDTO()
                        {
                            BidCount = context.ProjectBiddings.Where(p=>p.ProjectId==item.ProjectId).Count(),
                            ExpirationDate = item.EndDate,
                            Poster =item.PosterUser.ApplicationUserProfile.FullName,
                            Receiver=(item.ReceiverUser!=null)?item.ReceiverUser.ApplicationUserProfile.FullName:"Không có người nhận",
                            Status = item.Status,
                            Title = item.Title
                        };
                        ProjectForAdminDTO.Add(p);
                    }
                    projectPagging.Projects = ProjectForAdminDTO;
                    r.IsError = false;
                    r.Data = projectPagging;
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
            }
            return r;
        }
        public Result ProjectPaggingFreelancer(Guid userId, string index, string status)
        {
            Result r = new Result();
            try
            {
                int count;
                int page = Int32.Parse(index);
                if (page < 1)
                {
                    r.IsError = true;
                    return r;
                }
                using (var context = new MyDbContext())
                {
                    List<Project> projects = new List<Project>();
                    if (status != "Done" && status != "Refuse")
                    {
                        count = context.Projects
                            .Where(p => p.ProjectBiddings.Select(p => p.BidderId).Contains(userId) && p.Status == status).Count();
                        projects = context.Projects.Where(p => p.ProjectBiddings.Select(p => p.BidderId).Contains(userId) && p.Status == status)
                        .Include(p => p.ProjectBiddings)
                        .Include(p=>p.PosterUser)
                        .ThenInclude(u=>u.ApplicationUserProfile)
                        .Skip((page - 1) * 6).Take(6)
                        .OrderBy(p => p.EndDate)
                        .ToList();
                    }
                    else if (status == "Done")
                    {
                        count = context.Projects.Where(p => p.ReceiverId == userId && p.Status == status).Count();
                        projects = context.Projects.Where(p => p.ReceiverId == userId && p.Status == status)
                        .Include(p => p.ProjectBiddings)
                        .Include(p => p.PosterUser)
                        .ThenInclude(u => u.ApplicationUserProfile)
                        .Skip((page - 1) * 6).Take(6)
                        .OrderBy(p => p.EndDate)
                        .ToList();
                    }
                    else
                    {
                        count = context.Projects
                            .Where(p => p.ReceiverId != userId && (p.Status == "Done" || p.Status == "Cancel")).Count();
                        projects = context.Projects.Where(p => p.ReceiverId != userId && (p.Status == "Done"||p.Status=="Cancel"))
                        .Include(p => p.ProjectBiddings)
                        .Include(p => p.PosterUser)
                        .ThenInclude(u => u.ApplicationUserProfile)
                        .Skip((page - 1) * 6).Take(6)
                        .OrderBy(p => p.EndDate)
                        .ToList();
                    }
                    List<ProjectPaggingFreelancerDTO> projectPaggings = new List<ProjectPaggingFreelancerDTO>();
                    foreach (var item in projects)
                    {
                        ProjectPaggingFreelancerDTO p = new ProjectPaggingFreelancerDTO()
                        {
                            Id = item.ProjectId,
                            BiddingCount = context.ProjectBiddings.Where(p => p.ProjectId == item.ProjectId).Count(),
                            EndDate = item.EndDate,
                            PosterId = item.PosterId,
                            PosterName = item.PosterUser.ApplicationUserProfile.FullName,
                            BiddingMoney = item.ProjectBiddings.Where(p => p.BidderId == userId).FirstOrDefault().MoneyBidding,
                            Title = item.Title
                        };
                        projectPaggings.Add(p);
                    }
                    ResultProjectPaggingFreelancerDTO result = new ResultProjectPaggingFreelancerDTO()
                    {
                        page = page,
                        projects = projectPaggings,
                        StatusProject = status,
                        total = (count % 6 != 0) ? (count / 6 + 1) : (count / 6)
                    };
                    r.IsError = false;
                    r.Data = result;
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
            }
            return r;
        }
        public Result DeleteProject(Guid userId, string prjid)
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    Project p = context.Projects
                        .Where(p => p.PosterId == userId && p.ProjectId == Guid.Parse(prjid))
                        .FirstOrDefault();
                    if (p == null)
                    {
                        r.IsError = true;
                    }
                    else
                    {
                        context.Projects.Remove(p);
                        context.SaveChanges();
                        r.IsError = false;
                    }
                }
            }
            catch (Exception e)
            {
                r.IsError = true;
                r.Message = e.Message;
            }
            return r;
        }
    }
}
