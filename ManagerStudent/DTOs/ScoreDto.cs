using System.ComponentModel.DataAnnotations;

namespace ManagerStudent.DTOs
{
    public class ScoreDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]

        [MaxLength(100)]
        [MinLength(0)]
        public byte Value { get; set; }
    }
}
