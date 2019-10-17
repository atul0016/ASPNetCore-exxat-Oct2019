using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreWEBAPI.Models;

namespace CoreWEBAPI.Services
{
    public class StudentService : IService<Student, int>
    {

        private readonly StudentDbContext _ctx;

        /// <summary>
        /// Inject DbContext in to the ctor of the Repository class
        /// and access methods for CRUD Operations
        /// </summary>
        public StudentService(StudentDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Student> CreateAsync(Student enity)
        {
            try
            {
                var res = await _ctx.AddAsync(enity);
                await _ctx.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var res = await _ctx.Students.FindAsync(id);
                if (res == null)
                {
                    return false;
                }
                _ctx.Students.Remove(res);
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<Student>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateAsync(int id, Student enity)
        {
            throw new NotImplementedException();
        }
    }
}
