using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Attendance;
using api.Dto.WorkInfo;

namespace api.Dto.UserProfile
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string appUserId { get; set; } = string.Empty;
        public List<WorkInfoDto> WorkInfos { get; set; } = new List<WorkInfoDto>();

    }
}