using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.Attendance;
using api.Interface;
using api.Mappers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace api.Controllers
{
    [Route("api/attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {

        private readonly IAttendanceRepository _attendanceRepo;
        private readonly IUserProfileRepository _userProfileRepo;

        private readonly ApplicationDBContext _context;
        public AttendanceController(ApplicationDBContext context, IAttendanceRepository attendanceRepo,
        IUserProfileRepository userProfileRepo)
        {

            _context = context;
            _attendanceRepo = attendanceRepo;
            _userProfileRepo = userProfileRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var attendance = await _attendanceRepo.GetAllAsync();
            var attendanceDto = attendance.Select(x => x.ToAttendanceDto());
            return Ok(attendanceDto);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var attendance = await _attendanceRepo.GetByIdAsync(id);
            if(attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance.ToAttendanceDto());
        }
        [HttpPost("{userProfileId:int}")]
        public async Task<IActionResult> Create([FromRoute] int userProfileId, CreateAttendanceDto attendanceDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if(!await _userProfileRepo.IsExist(userProfileId))
            {
                return BadRequest("User does not exist");
            }

            var attendanceModel = attendanceDto.ToCreateAttendanceDto(userProfileId);
            await _attendanceRepo.CreateAsync(attendanceModel);
            return CreatedAtAction(nameof(GetById), new {id = attendanceModel.Id}, attendanceModel.ToAttendanceDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var attendanceModel = await _attendanceRepo.DeleteAsync(id);
            if(attendanceModel == null)
            {
                return NotFound("Attendance not found");
            }
            return Ok(attendanceModel);
        }
    }
}
