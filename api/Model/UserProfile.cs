using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("UserProfiles")]
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }


        public List<WorkInfo> WorkInfos { get; set; } = new List<WorkInfo>();
        // public List<Leave> Leave { get; set; } = new List<Leave>();
        // public List<Overtime> Overtime { get; set; } = new List<Overtime>();
        // public List<Undertime> Undertime { get; set; } = new List<Undertime>();
        // public List<OfficialBusiness> OfficialBusiness { get; set; } = new List<OfficialBusiness>();
    
    }
}