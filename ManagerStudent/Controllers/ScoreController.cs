using AutoMapper;
using ManagerStudent.Core.Entities;
using ManagerStudent.Core.Interfaces;
using ManagerStudent.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreRepository scoreRepository;
        private readonly IMapper mapper;

        public ScoreController(IScoreRepository _scoreRepository, IMapper _mapper)
        {
            scoreRepository = _scoreRepository;
            mapper = _mapper;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<StudentScoreDto>>> RegisterScores(List<ScoreDto> scores)
        {
            IEnumerable<Student> studentsWithScore = null;
            try
            {
                studentsWithScore = await scoreRepository.registerScore(mapper.Map<List<Score>>(scores));
            }
            catch (Exception ex)
            {
                BadRequest();
            }

            return Ok(mapper.Map<IEnumerable<StudentScoreDto>>(studentsWithScore));
        }
    }
}
