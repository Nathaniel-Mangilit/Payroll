using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Attendance;
using api.Model;

namespace api.Mappers
{
    public static class AttendanceMapper
    {

        public static AttendanceDto ToAttendanceDto(this Attendance attendanceModel)
        {
            return new AttendanceDto
            {
                Id = attendanceModel.Id,
                TimeLog = attendanceModel.TimeLog,
                LogStatus = attendanceModel.LogStatus,
                UserProfileId = attendanceModel.UserProfileId
            };
        }

        public static Attendance ToCreateAttendanceDto(this CreateAttendanceDto attendanceDto, int userProfileId)
        {
            return new Attendance
            {
                TimeLog = attendanceDto.TimeLog,
                LogStatus = attendanceDto.LogStatus,
                UserProfileId = userProfileId
            };
        }
    }
}