using BusinessObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CV
{
    public interface ICVRepository
    {
        Task<Result> GetCVByUserId(string UserId);
        Task<Result> UpdateCV(CvDTO cvDTO);
        Task<Result> CheckExistCvByUserId(string Userid);
    }
}
