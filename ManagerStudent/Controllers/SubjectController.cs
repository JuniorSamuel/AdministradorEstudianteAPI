using AutoMapper;
using ManagerStudent.Core.Entities;
using ManagerStudent.Core.Interfaces;
using ManagerStudent.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerSubject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly IMapper mapper;

        public SubjectController(ISubjectRepository _subject, IMapper _mapper)
        {
            subjectRepository = _subject;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SubjectDto>> GetSubject()
        {
            var student = await subjectRepository.Get();

            var studentDto = mapper.Map<IEnumerable<SubjectDto>>(student);
            return studentDto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetSubjectByID(int id)
        {
            var student = await subjectRepository.GetById(id);
            if (student == null)
                return NotFound();

            return Ok(mapper.Map<SubjectDto>(student));
        }

        [HttpPost]
        public async Task<ActionResult> PostSubject(SubjectCreateDto studentIn)
        {
            Subject newSubject = null;
            try
            {
               newSubject = await subjectRepository.create(mapper.Map<Subject>(studentIn));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction("GetSubjectByID", new { id = newSubject.Id }, mapper.Map<SubjectDto>(newSubject) );
        }

        [HttpPut]
        public async Task<ActionResult<SubjectDto>> UpdateSubject(SubjectDto studentDto)
        {
            var student = mapper.Map<SubjectDto, Subject>(studentDto);

            try
            {
                await subjectRepository.Update(student);
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
            var student = await subjectRepository.Delete(id);

            if (student == null) return BadRequest();

            return NoContent();
        }
    }
}
