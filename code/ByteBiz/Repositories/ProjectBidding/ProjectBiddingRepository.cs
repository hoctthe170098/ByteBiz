using BusinessObjects.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ProjectBidding
{
    public class ProjectBiddingRepository : IProjectBiddingRepository
    {
        private readonly ProjectBiddingDAO _projectBiddingDAO;
        public ProjectBiddingRepository()
        {
            _projectBiddingDAO = new ProjectBiddingDAO();
        }
        public Result CreateProjectBidding(Guid prjId, Guid bidderId, int money)
            =>_projectBiddingDAO.CreateProjectBidding(prjId, bidderId, money);
    }
}
