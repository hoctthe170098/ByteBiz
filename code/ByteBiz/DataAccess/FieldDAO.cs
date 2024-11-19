using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FieldDAO
    {
        public Result getListField()
        {
            Result r = new Result();
            try
            {
                using (var context = new MyDbContext())
                {
                    List<Field> fields = context.Fields.ToList();
                    List<FieldCountDTO> fieldsDTO = new List<FieldCountDTO>();
                    foreach (var item in fields)
                    {
                        int count = context.Projects.Where(p => p.FieldId == item.FieldId
                        && p.Status == "Hiring").Count();
                        FieldCountDTO fieldDAO = new FieldCountDTO()
                        {
                            Id = item.FieldId,
                            Name = item.FieldName,
                            CountProject = count,
                        };
                        fieldsDTO.Add(fieldDAO);
                    }
                    r.IsError = false;
                    r.Data = fieldsDTO;
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
    }
}
