using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class CompanionsRepository
    {
        private DoctorWhoCoreDbContext _Context;
        public CompanionsRepository(DoctorWhoCoreDbContext Context) {
            _Context=Context;
        }

        public Companion Get(int Id) {
            return _Context.Companions.FirstOrDefault(x => x.CompanionId == Id) ?? throw new Exception("404 DoctorNotFound");
        }
        public bool Create(CompanionDto companionDto)
        {   
              Companion companion= new() { 
                  CompanionName = companionDto.CompanionName,
                  WhoPlayed= companionDto.WhoPlayed
              };
            _Context.Companions.Add(companion);
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool Update(int Id,CompanionDto companionDto)
        {
            Companion companion = _Context.Companions.FirstOrDefault(x => x.CompanionId == Id) ?? throw new Exception("404 DoctorNotFound");
            companion.CompanionName = companionDto.CompanionName;
            companion.WhoPlayed= companionDto.WhoPlayed;
            _Context.Companions.Update(companion);
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool Remove(int Id)
        {
           var NumerOfRowsEffected=_Context.Database.ExecuteSqlInterpolated($"DELETE From Companions where CompanionId = {Id}");
          return NumerOfRowsEffected > 0;
        }
    }
}
