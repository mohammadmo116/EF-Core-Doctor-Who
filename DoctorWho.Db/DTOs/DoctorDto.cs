using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.DTOs
{
    public class DoctorDto
    {
        
        [Required]
        public int DoctorNumber { get; set; }
        [Required]
        public string DoctorName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public DateTime? FirstEpisodDate { get; set; }
        public DateTime? LastEpisodDate { get; set; }
 
    }
}
