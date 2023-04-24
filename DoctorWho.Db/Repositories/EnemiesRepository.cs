using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class EnemiesRepository
    {
        private DoctorWhoCoreDbContext _Context;
        public EnemiesRepository(DoctorWhoCoreDbContext Context)
        {
            _Context = Context;
        }
        public Enemy Get(int Id) {
           return _Context.Enemies.FirstOrDefault(x=>x.EnemyId == Id) ?? throw new Exception("404 DoctorNotFound");
        }

        public bool Create(EnemyDto enemyDto)
        {
            Enemy enemy = new()
            {
                EnemyName = enemyDto.EnemyName,
                Description = enemyDto.Description,   
            };
            _Context.Enemies.Add(enemy);
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool Update(int Id, EnemyDto enemyDto)
        {
            Enemy enemy = _Context.Enemies.FirstOrDefault(x => x.EnemyId == Id) ?? throw new Exception("404 EnemyNotFound");
            enemy.EnemyName= enemyDto.EnemyName;
            enemy.Description = enemyDto.Description;
            _Context.Enemies.Update(enemy);
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool Remove(int Id)
        {

            var NumerOfRowsEffected = _Context.Database.ExecuteSqlInterpolated($"DELETE From Enemies where EnemyId = {Id}");
            return NumerOfRowsEffected > 0;
        }
    }
}
