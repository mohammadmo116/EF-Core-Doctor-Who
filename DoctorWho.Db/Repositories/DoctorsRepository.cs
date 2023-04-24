using DoctorWho.Db.DTOs;
using DoctorWho.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class DoctorsRepository
    {

        private DoctorWhoCoreDbContext _Context;
        public DoctorsRepository(DoctorWhoCoreDbContext Context)
        {
            _Context = Context;
        }

        public List<Doctor> GetAllDoctors() {
            return _Context.Doctors.OrderBy(x => x.DoctorName).ToList();     
            
        }
        public bool Create(DoctorDto DoctorDto)
        {
            Doctor doctor = new()
            {
                DoctorName = DoctorDto.DoctorName,
                DoctorNumber= DoctorDto.DoctorNumber,
                BirthDate = DoctorDto.BirthDate,
                FirstEpisodDate = DoctorDto.FirstEpisodDate,
                LastEpisodDate = DoctorDto.LastEpisodDate,
                
                
            };
            _Context.Doctors.Add(doctor);
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool Update(int Id, DoctorDto DoctorDto)
        {
            Doctor doctor = _Context.Doctors.FirstOrDefault(x => x.DoctorId == Id) ?? throw new Exception("404 DoctorNotFound");
            doctor.DoctorName = DoctorDto.DoctorName;
            doctor.DoctorNumber = DoctorDto.DoctorNumber;
            doctor.BirthDate = DoctorDto.BirthDate;
            doctor.FirstEpisodDate = DoctorDto.FirstEpisodDate;
            doctor.LastEpisodDate = DoctorDto.LastEpisodDate;
            _Context.Doctors.Update(doctor);
            var NumerOfRowsEffected = _Context.SaveChanges();
            return NumerOfRowsEffected > 0;
        }
        public bool Remove(int Id)
        {
            var NumerOfRowsEffected = _Context.Database.ExecuteSqlInterpolated($"DELETE From Doctors where DoctorId = {Id}");
            return NumerOfRowsEffected > 0;
        }


    }
}
