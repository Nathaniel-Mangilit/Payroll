using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("Attendances")]
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime TimeLog { get; set; }
        public string LogStatus { get; set; } = string.Empty;
        public int? UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }

        
    }
}