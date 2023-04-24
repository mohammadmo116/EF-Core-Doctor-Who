using DoctorWho.Db;
using DoctorWho.Db.DTOs;
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
        public RepositoriesTests() {
            _builder = new DbContextOptionsBuilder<DoctorWhoCoreDbContext>();
            _builder.UseInMemoryDatabase("CanInsertAuthorToTheDataBase");
            _context = new DoctorWhoCoreDbContext(_builder.Options);
            _author=new AuthorsRepository(_context);
        }
        [TestMethod]
        public void CanInsertAuthor()
        {
            _author.Create(new AuthorDto() { AuthorName = "author1" });
            _author.Create(new AuthorDto() { AuthorName = "author2" });
            _author.Create(new AuthorDto() { AuthorName = "author3" });
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
    }
}