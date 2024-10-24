using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.UserProfile;
using api.Extensions;
using api.Helpers;
using api.Interface;
using api.Mappers;
using api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/userprofiles")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IUserProfileRepository _userProfileRepo;
        private readonly UserManager<AppUser> _userManager;
        public UserProfileController(ApplicationDBContext context, IUserProfileRepository userProfileRepo,
        UserManager<AppUser> userManager)
        {
            _context = context;
            _userProfileRepo = userProfileRepo;
            _userManager = userManager;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetallAsync([FromQuery] QueryObj queryObj)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var userProfile = await _userProfileRepo.GetallAsync(queryObj);
            var userProfileDto = userProfile.Select(x => x.ToUserProfileDto()).ToList();
            
            return Ok(userProfileDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var userProfile = await _userProfileRepo.GetByIdAsync(id);
            if(userProfile == null)
            {
                return NotFound();
            }
            return Ok(userProfile.ToUserProfileDto());          
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserProfileDto userDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
          

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userModel = userDto.ToCreateUserProfileDto();
            userModel.AppUserId = appUser?.Id;
            await _userProfileRepo.CreateAsync(userModel);
            
            return CreatedAtAction(nameof(GetById), new {id = userModel.Id}, userModel.ToUserProfileDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserProfileDto updateDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var userModel = await _userProfileRepo.UpdateAsync(id, updateDto);
            if(userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel.ToUserProfileDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var userModel = await _userProfileRepo.DeleteAsync(id);
                if(userModel == null)
                {
                    return NotFound();
                }
                return NoContent();
        }
    }
}

