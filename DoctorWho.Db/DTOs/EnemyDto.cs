using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.DTOs
{
    public class EnemyDto
    {
     
        [Required]
        public string EnemyName { get; set; } = string.Empty;
        public string? Description { get; set; }
      
    }
}
