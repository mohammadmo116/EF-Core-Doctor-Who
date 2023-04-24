using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class EpisodesRepository
    {
        private DoctorWhoCoreDbContext _Context;
        public EpisodesRepository(DoctorWhoCoreDbContext Context)
        {
            _Context = Context;
        }

        public bool Create(EpisodeDto episodeDto)
        {
            Episode episode = new()
            {
                SeriesNumber = episodeDto.SeriesNumber,
                EpisodNumber = episodeDto.EpisodNumber,
                EpisodType = episodeDto.EpisodType,
                Title = episodeDto.Title,
                EpisodDate = episodeDto.EpisodDate,
                Notes = episodeDto.Notes,
                DoctorId = episodeDto.DoctorId,
                AuthorId = episodeDto.AuthorId,

            };
            _Context.Episodes.Add(episode);
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool Update(int Id, EpisodeDto episodeDto)
        {
            Episode episode = _Context.Episodes.FirstOrDefault(x => x.EpisodeId == Id) ?? throw new Exception("404 DoctorNotFound");
            episode.SeriesNumber = episodeDto.SeriesNumber;
            episode.EpisodNumber = episodeDto.EpisodNumber;
            episode.EpisodType = episodeDto.EpisodType;
            episode.Title = episodeDto.Title;
            episode.EpisodDate = episodeDto.EpisodDate;
            episode.Notes = episodeDto.Notes;
            episode.DoctorId = episodeDto.DoctorId;
            episode.AuthorId = episodeDto.AuthorId;
            _Context.Episodes.Update(episode);
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool Remove(int Id)
        {
            var NumerOfRowsEffected = _Context.Database.ExecuteSqlInterpolated($"DELETE From Episodes where EpisodeId = {Id}");
            return NumerOfRowsEffected > 0;
        }
        public bool AddEnemyToEpisode(int EpisodeId, EnemyDto enemyDto)
        {
            Episode episode = _Context.Episodes.FirstOrDefault(x => x.EpisodeId == EpisodeId) ?? throw new Exception("404 DoctorNotFound");
            List<Enemy> enemies = new List<Enemy> { 
                new() { 
                        EnemyName = enemyDto.EnemyName, 
                        Description = enemyDto.Description  
                      }
            };
           
            episode.Enemies.AddRange(enemies);
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool AddExistnetEnemyToEpisode(int EpisodeId, int enemyId)
        {
            _Context.AddRange(
                new EnemyEpisode()
                {
                    EnemyId = enemyId,
                    EpisodeId = EpisodeId
                }
                );
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool AddCompanionToEpisode(int EpisodeId, CompanionDto companionDto)
        {
            Episode episode = _Context.Episodes.FirstOrDefault(x => x.EpisodeId == EpisodeId) ?? throw new Exception("404 DoctorNotFound");
            List<Companion> companions = new List<Companion> {
                new() {
                        CompanionName = companionDto.CompanionName,
                        WhoPlayed = companionDto.WhoPlayed
                      }
            };

            episode.Companions.AddRange(companions);
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool AddExistentCompanionToEpisode(int EpisodeId, int companionId)
        {
            _Context.AddRange(
                 new CompanionEpisode()
                 {
                     CompanionId = companionId,
                     EpisodeId = EpisodeId
                 }
                 );
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
    }
        
}
