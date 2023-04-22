using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Models
{
    public class Companion
    {
        public Companion(){
            Episodes=new List<Episode>();
        }

        public int CompanionId { get; set; }
        [Required]
        public string CompanionName { get; set;}=string.Empty;
        public string? WhoPlayed { get; set;}
        public List<Episode>? Episodes { get; set; }
    }
}
