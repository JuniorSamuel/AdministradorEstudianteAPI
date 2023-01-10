
using ManagerStudent.Core.Interfaces;
using ManagerStudent.Core.Entities;
using ManagerStudent.DTOs;
using ManagerStudent.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace ManagerStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentController(IStudentRepository _student, IMapper _mapper)
        {
            studentRepository = _student;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentDto>> GetStudent()
        {
            var students = await studentRepository.Get();

            return mapper.Map<IEnumerable<StudentDto>>(students);
            
        }

        [HttpGet()]
        [Route("attendance")]
        public async Task<IEnumerable<Student>> GetEstudianteWithAttendance()
        {
            var students = await studentRepository.GetAllWith(StudentInclude.Attendance);

            return students;
        }

        [HttpGet()]
        [Route("score")]
        public async Task<IEnumerable<Student>> GetEstudianteWithScore()
        {
            var students = await studentRepository.GetAllWith(StudentInclude.Score);

            return students;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentByID(int id)
        {
            var student = await studentRepository.GetById(id);
            if (student == null)
                return NotFound();

            return Ok(mapper.Map<StudentDto>(student));
        }

        [HttpPost]
        public async Task<ActionResult> PostStudent(StudentCreateDto studentIn)
        {
            Student newStudent = null;
            try
            {
                newStudent = await studentRepository.create(mapper.Map<Student>(studentIn));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction("GetStudentByID", new { id = newStudent.Id }, mapper.Map<StudentDto>(newStudent));

        }

        [HttpPut]
        public async Task<ActionResult<StudentDto>> UpdateStudent(StudentDto studentDto)
        {
            var student = mapper.Map<StudentDto, Student>(studentDto);

            try
            {
                await studentRepository.Update(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(studentDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var student = await studentRepository.Delete(id);

            if (student == null) return BadRequest();

            return NoContent();
        }
    }
}
