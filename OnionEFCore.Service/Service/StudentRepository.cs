using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Core.Domain.Model;
using Core.Repository.Repository;

namespace Core.Repository.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDBContext context) : base(context) { }
        public async Task<Student?> GetStudentDetailsByIdAsync(int id)
        {
            return await _dbSet
                .Include(s => s.Profile)
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        public override async Task<Student?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(s => s.Profile)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
