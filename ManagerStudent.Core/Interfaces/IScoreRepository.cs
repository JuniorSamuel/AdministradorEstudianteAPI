using ManagerStudent.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerStudent.Core.Interfaces;

public interface IScoreRepository
{
    Task<IEnumerable<Student>> registerScore(List<Score> Scores);
}
