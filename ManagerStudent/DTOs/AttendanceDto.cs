using System.ComponentModel.DataAnnotations;

namespace ManagerStudent.DTOs
{
    public class AttendanceCreateDto
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd")]
        public DateTime Date { get; set; }

        [Required]
        public char Status { get; set; }
    }

    public class AttendanceDto : AttendanceCreateDto
    {
        [Required]
        public int Id { get; set; }
    }
}
