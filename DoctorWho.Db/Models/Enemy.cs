using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Models
{
    public class Enemy
    {
        public Enemy() {
            Episodes = new List<Episode>();
        }
        public int EnemyId { get; set; }
        [Required]
        public string EnemyName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Episode>? Episodes { get; set; }

        public static explicit operator List<object>(Enemy v)
        {
            throw new NotImplementedException();
        }
    }
}
