using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repository.Data;
using Core.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Core.Service.Service;

namespace Core.Repository.Repository
{
    public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(AppDBContext context) : base(context) { }
        private bool EnrollmentExistsAsync(int courseId, int studentId)
        {
            return _dbSet.Any(e => e.CourseId == courseId && e.StudentId == studentId);
        }
        public async Task<IEnumerable<Enrollment>> GetCourseEnrollmentsAsync(int courseId)
        {
            return await _dbSet
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.CourseId == courseId)
                .ToListAsync();
        }
        public override async Task AddAsync(Enrollment entity)
        {
            if (EnrollmentExistsAsync(entity.CourseId, entity.StudentId))
            {
                throw new Exception($"Enrollment for student {entity.StudentId} in course {entity.CourseId} already exists.");
            }

            await base.AddAsync(new Enrollment
            {
                CourseId = entity.CourseId,
                StudentId = entity.StudentId
            });
        }

    }
}
