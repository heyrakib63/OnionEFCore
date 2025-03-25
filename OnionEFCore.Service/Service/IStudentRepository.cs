using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model;
using Core.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Core.Repository.Repository;
using Core.Service.Service;

namespace Core.Repository.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student?> GetStudentDetailsByIdAsync(int id);
    }
}
