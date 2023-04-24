using DoctorWho.Db;
using DoctorWho.Db.DTOs;
using DoctorWho.Db.Migrations;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace DoctorWhoTest
{
    [TestClass]
    public class RepositoriesTests
    {
        private DbContextOptionsBuilder<DoctorWhoCoreDbContext> _builder;
        private DoctorWhoCoreDbContext _context;
        private AuthorsRepository _author;
        private DoctorsRepository _doctor;
        private CompanionsRepository _companion;
        private EpisodesRepository _episode;
        public RepositoriesTests() {
            _builder = new DbContextOptionsBuilder<DoctorWhoCoreDbContext>();
            _builder.UseInMemoryDatabase("CanInsertAuthorToTheDataBase");
            _context = new DoctorWhoCoreDbContext(_builder.Options);
            _author=new AuthorsRepository(_context);
            _author.Create(new AuthorDto() { AuthorName = "author1" });
            _author.Create(new AuthorDto() { AuthorName = "author2" });
            _author.Create(new AuthorDto() { AuthorName = "author3" });
            _doctor = new DoctorsRepository(_context);
            _doctor.Create(new DoctorDto() { DoctorName = "d1", DoctorNumber = 1 });
            _doctor.Create(new DoctorDto() { DoctorName = "d2", DoctorNumber = 2 });
            _doctor.Create(new DoctorDto() { DoctorName = "d3", DoctorNumber = 3 });
            _companion = new CompanionsRepository(_context);
            _companion.Create(new CompanionDto() { CompanionName="c0",WhoPlayed="p0"});
            _episode=new EpisodesRepository(_context);
            _episode.Create(new EpisodeDto() {Title="t1",SeriesNumber=1,Notes="fdsf"
                ,EpisodType="Dfs" });
        }
        [TestMethod]
        public void CanInsertAuthor()
        {
            
            var isAdded = _author.Create(new AuthorDto() { AuthorName = "author4" });
            Assert.AreEqual(true, isAdded);

        }
        [TestMethod]

        public void CanUpdateAuthor()
        {
            
            var Id = _context.Authors.FirstOrDefault().AuthorId;
            var isUpdated = _author.Update(Id, new AuthorDto() { AuthorName = "author7" });
            Assert.AreEqual(true, isUpdated);

        }
        [TestMethod]
        public void CanRemoveAuthor()
        {
            var Id = _context.Authors.FirstOrDefault().AuthorId;
            var isRemoved = _author.Remove(Id);
                Assert.AreEqual(true, isRemoved);
           
        }
        [TestMethod]
        public void RetrieveAllDoctors()
        {
            var doctors = _doctor.GetAllDoctors();
            Assert.AreEqual(doctors.Count(), _context.Doctors.Count());

        }
        [TestMethod]
        public void CanGetCompanionById()
        {
            var Id = _context.Companions.FirstOrDefault().CompanionId;
            var companion= _companion.Get(Id);
            Assert.AreEqual(companion.CompanionId, Id);

        }
        [TestMethod]
        public void CanAddEnemyToEpisode()
        {
            
            var Id = _context.Episodes.FirstOrDefault().EpisodeId;
            var isAdded = _episode.AddEnemyToEpisode(Id, new EnemyDto() { EnemyName = "e1", Description = "dsf" });
            Assert.AreEqual(true, isAdded);

        }
        [TestMethod]
        public void CanAddExistentCompanionToEpisode()
        {

            var EpisodeId = _context.Episodes.FirstOrDefault().EpisodeId;
            var CompanionId = _context.Companions.FirstOrDefault().CompanionId;
            var isAdded = _episode.AddExistentCompanionToEpisode(EpisodeId, CompanionId);
            Assert.AreEqual(true, isAdded);

        }
        
    }
}