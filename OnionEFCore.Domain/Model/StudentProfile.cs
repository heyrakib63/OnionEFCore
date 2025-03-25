using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Model
{
    public class StudentProfile
    {
        public int Id { get; set; }
        public string Bio { get; set; } = string.Empty;
        public Student? Student { get; set; }
    }
}
