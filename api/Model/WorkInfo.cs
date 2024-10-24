using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("WorkInfos")]
    public class WorkInfo
    {
        public int Id { get; set; }
        public string Company { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string SuperVisor { get; set; } = string.Empty;
        public string WorkPlace { get; set; } = string.Empty;
        public int? UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
    }
}