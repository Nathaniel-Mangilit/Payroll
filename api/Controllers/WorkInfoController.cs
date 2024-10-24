using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.WorkInfo;
using api.Extensions;
using api.Interface;
using api.Mappers;
using api.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/workinfo")]
    [ApiController]
    public class WorkInfoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IWorkInfoRepository _workInfoRepo;
        private readonly IUserProfileRepository _userProfileRepo;
        public WorkInfoController(ApplicationDBContext context, IWorkInfoRepository workInfoRepo
        , IUserProfileRepository userProfileRepo)
        {

            _context = context;
            _workInfoRepo = workInfoRepo;
            _userProfileRepo = userProfileRepo;
           
        }
        [HttpGet]
        public async Task<IActionResult> GetallAsync()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var workInfo = await _workInfoRepo.GetAllAsync();
            var workInfoDto = workInfo.Select(x => x.ToWorkInfoDto());
            return Ok(workInfoDto);    
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var workInfo = await _workInfoRepo.GetByIdAsync(id);
            if(workInfo == null)
            {
                return NotFound();
            }
            return Ok(workInfo.ToWorkInfoDto());          
        }
        [HttpPost("{userProfileId:int}")]
        public async Task<IActionResult> Create([FromRoute] int userProfileId, CreateWorkInfoDto workDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if(!await _userProfileRepo.IsExist(userProfileId))
            {
                return BadRequest("User does not exist");
            }
            var workModel = workDto.ToCreateWorkInfoDto(userProfileId);

            await _workInfoRepo.CreateAsync(workModel);
            return CreatedAtAction(nameof(GetById), new {id = workModel.Id}, workModel.ToWorkInfoDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateWorkInfoDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var existingInfo = await _workInfoRepo.GetByIdAsync(id);
            if(existingInfo == null)
            {
                return NotFound();
            }
            var workModel = await _workInfoRepo.UpdateAsync(id, updateDto);
             if(workModel == null)
             {
                return NotFound();
             }
             return Ok(workModel.ToWorkInfoDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var workModel = await _workInfoRepo.DeleteAsync(id);
                if(workModel == null)
                {
                    return NotFound();
                }
            return NoContent();
        }
    }
}