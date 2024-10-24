using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.WorkInfo;
using api.Model;

namespace api.Mappers
{
    public static class WorkInfoMapper
    {
        public static WorkInfoDto ToWorkInfoDto(this WorkInfo workModel)
        {
            return new WorkInfoDto
            {
                Id = workModel.Id,
                Company = workModel.Company,
                Department = workModel.Department,
                Position = workModel.Position,
                SuperVisor = workModel.SuperVisor,
                WorkPlace = workModel.WorkPlace,
                UserProfileId = workModel.UserProfileId
            };
        }

        public static WorkInfo ToCreateWorkInfoDto(this CreateWorkInfoDto workDto, int userProfileId)
        {
            return new WorkInfo
            {
                Company = workDto.Company,
                Department = workDto.Department,
                Position = workDto.Position,
                SuperVisor = workDto.SuperVisor,
                WorkPlace = workDto.WorkPlace,
                UserProfileId = userProfileId

            };
        }
    }
}