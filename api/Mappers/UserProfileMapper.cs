using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.UserProfile;
using api.Model;

namespace api.Mappers
{
    public static class UserProfileMapper
    {
        public static UserProfileDto ToUserProfileDto(this UserProfile userModel)
        {
            return new UserProfileDto
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                MiddleName = userModel.MiddleName,
                LastName = userModel.LastName,
                Gender = userModel.Gender,
                BirthDate = userModel.BirthDate,
                appUserId = userModel.AppUserId,
                WorkInfos = userModel.WorkInfos.Select(x => x.ToWorkInfoDto()).ToList(),
               
            };
        }
        public static UserProfile ToCreateUserProfileDto(this CreateUserProfileDto userDto)
        {
            return new UserProfile
            {
                FirstName = userDto.FirstName,
                MiddleName = userDto.MiddleName,
                LastName = userDto.LastName,
                Gender = userDto.Gender,
                BirthDate = userDto.BirthDate
            };
        }
    }
}