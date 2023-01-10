using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStudent.Core.Entities
{
    public class Score: BaseEntity
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public byte Value { get; set; }
    }
}
