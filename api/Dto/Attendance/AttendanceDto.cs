using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Attendance
{
    public class AttendanceDto
    {
        public int Id { get; set; }
        public DateTime TimeLog { get; set; }
        public string LogStatus { get; set; } = string.Empty;
        public int? UserProfileId { get; set; }
    }
}