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
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository attendanceRepository;
        private readonly IMapper mapper;

        public AttendanceController(IAttendanceRepository _attendanceRepository, IMapper _mapper)
        {
            attendanceRepository = _attendanceRepository;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceDto>>> Get()
        {
            var attendances = await attendanceRepository.GetAttendances();
            return Ok(mapper.Map<IEnumerable<AttendanceDto>>(attendances));
        }

        [HttpPost]
        public async Task<ActionResult> InsertAttendance(List<AttendanceCreateDto> attendancesDto)
        {
            var attendances = mapper.Map<List<Attendance>>(attendancesDto);

            var listInsert = await attendanceRepository.InsertAttendaces(attendances);

            if (listInsert is null) return BadRequest();
            return Ok(listInsert);
        }

        [HttpGet("{date}")]
        public async Task<ActionResult<IEnumerable<AttendanceDto>>> GetByDate(DateTime date)
        {
            var attendances = await attendanceRepository.GetByDate(date);
            return Ok(attendances);
        }
    }
}
