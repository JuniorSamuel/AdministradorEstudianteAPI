using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStudent.Core.Entities
{
    public class Attendance : BaseEntity
    {
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public char Status { get; set; }
    }
}
