using DoctorWho.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db
{
    public class DoctorWhoCoreDbContext:DbContext
    {
        public DbSet<Enemy>? Enemies { get; set; }
        public DbSet<Author>? Authors { get; set; }
        public DbSet<Doctor>? Doctors { get; set; }
        public DbSet<Episode>? Episodes { get; set; }
        public DbSet<Companion>? Companions { get; set; }


        public DoctorWhoCoreDbContext()
        {

        }

        public DoctorWhoCoreDbContext(DbContextOptions<DoctorWhoCoreDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=DoctorWhoCore;Trusted_Connection=True;");
            }
        }
  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Enemy>()
                  .HasMany(a => a.Episodes)
                  .WithMany(b => b.Enemies)
                  .UsingEntity<EnemyEpisode>(
                  join => join
                  .HasOne<Episode>()
                  .WithMany()
                  .HasForeignKey(ca => ca.EpisodeId),
                 join => join
                  .HasOne<Enemy>()
                  .WithMany()
                  .HasForeignKey(e => e.EnemyId));

            modelBuilder.Entity<Companion>()
               .HasMany(a => a.Episodes)
               .WithMany(b => b.Companions)
               .UsingEntity<CompanionEpisode>(
               join => join
               .HasOne<Episode>()
               .WithMany()
               .HasForeignKey(ca => ca.EpisodeId),
              join => join
               .HasOne<Companion>()
               .WithMany()
               .HasForeignKey(e => e.CompanionId));

            modelBuilder.Entity<EnemyEpisode>().HasKey(e=>new { e.EnemyId,e.EpisodeId});
            modelBuilder.Entity<CompanionEpisode>().HasKey(e => new { e.CompanionId, e.EpisodeId });
            modelBuilder.Entity<EnemyEpisode>().Property(e => e.EnemyId).HasColumnName("EnemiesEnemyId");
            modelBuilder.Entity<EnemyEpisode>().Property(e => e.EpisodeId).HasColumnName("EpisodesEpisodeId");
            modelBuilder.Entity<CompanionEpisode>().Property(e=>e.CompanionId).HasColumnName("CompanionsCompanionId");
            modelBuilder.Entity<CompanionEpisode>().Property(e => e.EpisodeId).HasColumnName("EpisodesEpisodeId");

      

               /*List<Enemy> enemiesList = new List<Enemy> {
                     new Enemy{EnemyId=1,EnemyName="pain",Description="destroy the word"},
                     new Enemy{EnemyId=2,EnemyName="obito",Description="waking madara up"},
                     new Enemy{EnemyId=3,EnemyName="Madara",Description="tsokoyome"},
                     new Enemy{EnemyId=4,EnemyName="Kaguya",Description="eat the forbidden fruit"},
                     new Enemy{EnemyId=5,EnemyName="Boruto",Description="destroy Naruto anime"}
                 };


                 List<Author> AuthersList =new List<Author> {
                     new Author{AuthorId=1,AuthorName="Minato"},
                     new Author{AuthorId=2,AuthorName="Minato"},
                     new Author{AuthorId=3, AuthorName="Minato"},
                     new Author{AuthorId=4,AuthorName="Jiraya"},
                     new Author{AuthorId=5,AuthorName="Tsunadi"}
                 };


                 List<Doctor> DoctorsList = new List<Doctor> {
                     new Doctor{DoctorId=1,DoctorName="Minato",DoctorNumber=564841,BirthDate=new DateTime(2000,2,2,0,0,0),FirstEpisodDate=new DateTime(2011,1,12,0,0,0),LastEpisodDate=new DateTime(2020,11,10,0,0,0)},
                     new Doctor{DoctorId=2,DoctorName="demon",DoctorNumber=51654,BirthDate=new DateTime(2002,3,3,0,0,0),FirstEpisodDate=new DateTime(2021,1,1,0,0,0),LastEpisodDate=new DateTime(2022,11,10,0,0,0)},
                     new Doctor{DoctorId=3,DoctorName="pain",DoctorNumber=5154,BirthDate=new DateTime(2005,4,3,0,0,0),FirstEpisodDate=new DateTime(2014,1,12,0,0,0),LastEpisodDate=new DateTime(2020,12,11,0,0,0)},
                     new Doctor{DoctorId=4,DoctorName="kakashi",DoctorNumber=2,BirthDate=new DateTime(2006,5,5,0,0,0),FirstEpisodDate=new DateTime(2013,1,12,0,0,0),LastEpisodDate=new DateTime(2020,2,6,0,0,0)},
                     new Doctor{DoctorId=5,DoctorName="shikamaro",DoctorNumber=3,BirthDate=new DateTime(2008,6,7,0,0,0),FirstEpisodDate=new DateTime(2012,1,12,0,0,0),LastEpisodDate=new DateTime(2020,2,10,0,0,0)}
                 };


                 List<Episode> EpisodesList = new List<Episode> {
                     new Episode{EpisodeId=1,AuthorId=1,DoctorId=1,EpisodDate=new DateTime(2020,1,1),EpisodNumber=1,EpisodType="a",Notes="ddd",SeriesNumber=2,Title="vv"},
                     new Episode{EpisodeId=2,AuthorId=3,DoctorId=2,EpisodDate=new DateTime(2030,1,1),EpisodNumber=3,EpisodType="b",Notes="aaa",SeriesNumber=1,Title="vva"},
                     new Episode{EpisodeId=3,AuthorId=2,DoctorId=5,EpisodDate=new DateTime(2000,1,1),EpisodNumber=2,EpisodType="c",Notes="fdsfds",SeriesNumber=3,Title="va"},
                     new Episode{EpisodeId=4,AuthorId=5,DoctorId=3,EpisodDate=new DateTime(2020,1,1),EpisodNumber=5,EpisodType="d",Notes=" ",SeriesNumber=4,Title="aavv"},
                     new Episode{EpisodeId=5,AuthorId=4,DoctorId=4,EpisodDate=new DateTime(2005,10,1),EpisodNumber=4,EpisodType="f",Notes="dsfdsf",SeriesNumber=5,Title="ddas"}
                 };

                List<Companion> companions = new List<Companion> {
                     new Companion{CompanionId=1,CompanionName="c1",WhoPlayed="p1"},
                     new Companion{CompanionId=2,CompanionName="c2",WhoPlayed="p2"},
                     new Companion{CompanionId=3,CompanionName="c3",WhoPlayed="p3"},
                     new Companion{CompanionId=4,CompanionName="c4",WhoPlayed="p4"},
                     new Companion{CompanionId=5,CompanionName="c5",WhoPlayed="p5"}
                 };

                 List<EnemyEpisode> EnemiesEpisodesList = new List<EnemyEpisode> {
                     new EnemyEpisode{EnemyId=1,EpisodeId=2},
                     new EnemyEpisode{EnemyId=3,EpisodeId=4},
                     new EnemyEpisode{EnemyId=2,EpisodeId=4},
                     new EnemyEpisode{EnemyId=4,EpisodeId=1},
                     new EnemyEpisode{EnemyId=5,EpisodeId=5}
                 };

                 List<CompanionEpisode> CompanionesEpisodesList = new List<CompanionEpisode> {
                     new CompanionEpisode{CompanionId=1,EpisodeId=4},
                     new CompanionEpisode{CompanionId=2,EpisodeId=5},
                     new CompanionEpisode{CompanionId=3,EpisodeId=4},
                     new CompanionEpisode{CompanionId=4,EpisodeId=1},
                     new CompanionEpisode{CompanionId=5,EpisodeId=5}
                 };

                 modelBuilder.Entity<Enemy>().HasData(enemiesList);
                 modelBuilder.Entity<Author>().HasData(AuthersList);
                 modelBuilder.Entity<Doctor>().HasData(DoctorsList);
                 modelBuilder.Entity<Episode>().HasData(EpisodesList);
                 modelBuilder.Entity<Companion>().HasData(companions);
                 modelBuilder.Entity<EnemyEpisode>().HasData(EnemiesEpisodesList);
                 modelBuilder.Entity<CompanionEpisode>().HasData(CompanionesEpisodesList);*/
        }

    }


}
