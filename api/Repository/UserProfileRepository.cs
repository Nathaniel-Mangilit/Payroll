using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.UserProfile;
using api.Helpers;
using api.Interface;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDBContext _context;
        public UserProfileRepository(ApplicationDBContext context)
        /// Constructor for UserProfileRepository.
        {
            _context = context;
        }

        public async Task<UserProfile> CreateAsync(UserProfile userModel)
        {
            await _context.UserProfiles.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<UserProfile?> DeleteAsync(int id)
        {
           var userModel = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == id);

           if(userModel == null)
           {
            return null;
           }
           _context.UserProfiles.Remove(userModel);
           await _context.SaveChangesAsync();
           return userModel;
        }

        public async Task<List<UserProfile>> GetallAsync(QueryObj queryObj)
        {
          var query = _context.UserProfiles.Include(w => w.WorkInfos).AsQueryable();

          if(!string.IsNullOrWhiteSpace(queryObj.AppUserId)){
            query = query.Where(x => x.AppUserId.Contains(queryObj.AppUserId));
          }
          
          if(!string.IsNullOrWhiteSpace(queryObj.FirstName)){
            query = query.Where(x => x.FirstName.Contains(queryObj.FirstName));
          }
          return await query.ToListAsync();
        }

        public async Task<UserProfile?> GetByIdAsync(int id)
        {
           return await _context.UserProfiles.Include(w => w.WorkInfos).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> IsExist(int id)
        {
            return _context.UserProfiles.AnyAsync(x => x.Id == id);
        }

        public async Task<UserProfile?> UpdateAsync(int id, UpdateUserProfileDto updateDto)
        {
           var existingUser = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == id);
           if(existingUser == null)
           {
            return null;
           }
           existingUser.FirstName = updateDto.FirstName;
           existingUser.MiddleName = updateDto.MiddleName;
           existingUser.LastName = updateDto.LastName;
           existingUser.Gender = updateDto.Gender;
           existingUser.BirthDate = updateDto.BirthDate;
           
           await _context.SaveChangesAsync();
           return existingUser;

        }
    }
}