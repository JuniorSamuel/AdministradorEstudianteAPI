using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStudent.Core.Entities
{
    public class Subject: BaseEntity
    {
        public Subject()
        {
            Scores = new HashSet<Score>();
        }

        public string Name { get; set; } = null!;

        public ICollection<Score> Scores { get; set; }
    }
}
