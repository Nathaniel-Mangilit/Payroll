using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto.WorkInfo
{
    public class WorkInfoDto
    {
        public int Id { get; set; }
        public string Company { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string SuperVisor { get; set; } = string.Empty;
        public string WorkPlace { get; set; } = string.Empty;
        public int? UserProfileId { get; set; } 
    }
}