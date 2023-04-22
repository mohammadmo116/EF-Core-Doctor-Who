using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Models
{
    public class Doctor
    {
        public Doctor() {
            Episodes=new List<Episode>();
        }
        public int DoctorId { get; set; }
        [Required]
        public int DoctorNumber { get; set; }
        [Required]
        public string DoctorName { get; set; }=string.Empty;
        public DateTime? BirthDate { get; set; }
        public DateTime? FirstEpisodDate { get; set; }
        public DateTime? LastEpisodDate { get; set; }
        public List<Episode>? Episodes { get; set; }

    }

}
