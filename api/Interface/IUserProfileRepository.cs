using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.UserProfile;
using api.Helpers;
using api.Model;

namespace api.Interface
{
    public interface IUserProfileRepository
    {
        Task<List<UserProfile>> GetallAsync(QueryObj queryObj);
        Task<UserProfile?> GetByIdAsync(int id);
        Task<UserProfile> CreateAsync(UserProfile userModel);
        Task<UserProfile?> UpdateAsync(int id, UpdateUserProfileDto updateDto);
        Task<UserProfile?> DeleteAsync(int id);
        Task<bool> IsExist(int id);
    }
}