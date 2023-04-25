using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.DbFunctions
{
    public class spTopThreeEpisodeCompanions
    {
        public string? title { get; set; }
        public int? CompanionsCount { get; set; }
        public override string ToString()
        {
            return "title: " + title + " -  CompanionsCount: " + CompanionsCount+"\n";
        }
    }
}
