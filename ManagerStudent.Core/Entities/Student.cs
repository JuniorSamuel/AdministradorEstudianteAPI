using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStudent.Core.Entities
{
    public class Student: BaseEntity
    {
        public Student()
        {
            Scores = new HashSet<Score>();
            Attendances = new HashSet<Attendance>();
        }

        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Comment { get; set; } = null!;

        public ICollection<Score> Scores { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
