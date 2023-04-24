using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class AuthorsRepository
    {
        private DoctorWhoCoreDbContext _Context;
        public AuthorsRepository(DoctorWhoCoreDbContext Context)
        {
            _Context = Context;
        }
      
        public bool Create(AuthorDto authorDto)
        {
            Author author = new()
            {
                AuthorName= authorDto.AuthorName
            };
            _Context.Authors.Add(author);
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool Update(int Id,AuthorDto authorDto)
        {
            Author author = _Context.Authors.FirstOrDefault(x => x.AuthorId == Id) ?? throw new Exception("404 DoctorNotFound");
            author.AuthorName = authorDto.AuthorName;
            _Context.Authors.Update(author);
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool Remove(int Id)
        {
           Author autho= _Context.Authors.FirstOrDefault(x => x.AuthorId == Id) ?? throw new Exception("404 DoctorNotFound");
            _Context.Authors.Remove(autho);
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
           /* var NumerOfRowsEffected = _Context.Database.ExecuteSqlInterpolated($"DELETE From Authors where AuthorId = {Id}");
            return NumerOfRowsEffected > 0;*/
        }
    }
}
