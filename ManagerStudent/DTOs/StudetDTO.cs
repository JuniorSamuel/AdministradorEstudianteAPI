using ManagerStudent.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace ManagerStudent.DTOs
{
    public class StudentCreateDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [MaxLength(200)]
        public string Comment { get; set; } = null!;
    }

    public class StudentDto : StudentCreateDto
    {
        [Required]
        public int Id { get; set; }

    }

    public class StudentScoreDto: StudentDto
    {
        public List<Score> Scores{ get; set; }
    }
}
