using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Repository.Repository;
using Core.Domain.Model;

namespace Core.Service.Service
{
    
    public interface IEnrollmentRepository : IRepository<Enrollment>
    {
        Task<IEnumerable<Enrollment>> GetCourseEnrollmentsAsync(int courseId);
    }
}
