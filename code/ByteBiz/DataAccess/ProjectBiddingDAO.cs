using BusinessObjects.DTO;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProjectBiddingDAO
    {
        public Result CreateProjectBidding(Guid prjId,Guid bidderId,int money)
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    Project p = context.Projects.FirstOrDefault(p=>p.ProjectId== prjId);
                    if (p.Status!="Hiring")
                    {
                        r.IsError = true;
                        r.Message = "Project này hết hạn báo giá";
                        return r;
                    }
                    ProjectBidding bid = context.ProjectBiddings.Where(p=>p.ProjectId == prjId
                    &&p.BidderId==bidderId).FirstOrDefault();
                    if (bid != null)
                    {
                        r.IsError = true;
                        r.Message = "Bạn đã báo giá cho project này rồi";
                    }
                    else
                    {
                        ProjectBidding pBid = new ProjectBidding()
                        {
                            BidderId = bidderId,
                            DateBidding = DateTime.Now,
                            MoneyBidding = money,
                            ProjectId = prjId
                        };
                        context.ProjectBiddings.Add(pBid);
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
