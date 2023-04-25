using DoctorWho.Db.DbFunctions;
using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.DbViews
{
    public class ViewEpisodes
    {
    
        public string? AuthorName { get; set; }
        public string? DoctorName { get; set; } 
        public string? Companions { get; set; }
        public string? Enemies { get; set; }
        public int EpisodeId { get; set; }
        public int? SeriesNumber { get; set; }
        public int? EpisodNumber { get; set; }
        public string? EpisodType { get; set; }
        public string? Title { get; set; } = string.Empty;
        public DateTime? EpisodDate { get; set; }
        public string? Notes { get; set; }
        public int? DoctorId { get; set; }
        public int? AuthorId { get; set; }
    
    }
}
