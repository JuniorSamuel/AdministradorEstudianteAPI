using AutoMapper;
using ManagerStudent.Core.Entities;
using ManagerStudent.DTOs;

namespace ManagerStudent.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<StudentCreateDto, Student>();
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentScoreDto>();

            CreateMap<SubjectCreateDto, Subject>();
            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectDto, Subject>();

            CreateMap<ScoreDto, Score>();

            CreateMap<AttendanceCreateDto, Attendance>();
            CreateMap<Attendance, AttendanceDto>();
        }
    }
}
