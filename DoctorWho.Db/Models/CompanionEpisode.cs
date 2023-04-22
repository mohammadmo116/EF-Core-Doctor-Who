using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Models
{

    
    public class CompanionEpisode
    { 
        public int CompanionId { get; set; }
        public int EpisodeId { get; set; }
       
    }
}
