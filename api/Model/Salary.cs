using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Salary
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalEarning { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalDeduction { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetSalary { get; set; }
        public int? UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }

    }
}