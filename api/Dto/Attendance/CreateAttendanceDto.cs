using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.Attendance
{
    public class CreateAttendanceDto
    {
        public DateTime TimeLog { get; set; }
        public string LogStatus { get; set; } = string.Empty;

        internal Model.Attendance ToCreateAttendanceDto()
        {
            throw new NotImplementedException();
        }
    }
}