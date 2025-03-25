using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public StudentProfile? Profile { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = [];
    }
}
