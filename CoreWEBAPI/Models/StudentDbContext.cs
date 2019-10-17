using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace CoreWEBAPI.Models
{
    /// <summary>
    /// The class will use Comnnection String and Map with
    /// Database to Create database and Generate Table with
    /// Table Mapping with the Model class
    /// </summary>
    public class StudentDbContext : DbContext
    {
        /// <summary>
        /// This will read the connection string from
        /// ConfigureServices() from Startup class
        /// </summary>
        /// <param name="options"></param>
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
                :base(options)
        {
        }

        // define model mapping
        public DbSet<Student> Students { get; set; }

        // the model mapping configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
