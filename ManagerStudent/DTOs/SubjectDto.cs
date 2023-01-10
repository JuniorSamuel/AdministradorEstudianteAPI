using System.ComponentModel.DataAnnotations;

namespace ManagerStudent.DTOs
{
    public class SubjectCreateDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = null!;
    }

    public class SubjectDto : SubjectCreateDto
    {
        [Required]
        public int Id { get; set; }
    }
}
