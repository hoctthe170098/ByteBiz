using BusinessObjects.DTO;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Field
{
    public class FieldRepository :IFieldRepository
    {
        private readonly FieldDAO _fieldDAO;
        public FieldRepository() { 
            _fieldDAO = new FieldDAO();
        }
        public Result getListField()=>_fieldDAO.getListField();
    }
}
