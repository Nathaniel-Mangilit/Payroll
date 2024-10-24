using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("Undertimes")]
    public class Undertime
    {
        public int Id { get; set; }
        public string TypeofLeave { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public string Status { get; set; } = string.Empty;
        public int? UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
    }
}