using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.DbFunctions
{
    public class spTopThreeEpisodeEnemies
    {
        public string? title { get; set; }
        public int? EnemiesCount { get; set; }
        public override string ToString()
        {
            return "title: " + title + " -  EnemiesCount: " + EnemiesCount+"\n";
        }
    }
}
