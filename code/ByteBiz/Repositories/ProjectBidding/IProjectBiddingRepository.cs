using BusinessObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ProjectBidding
{
    public interface IProjectBiddingRepository
    {
        Result CreateProjectBidding(Guid prjId, Guid bidderId, int money);
    }
}
