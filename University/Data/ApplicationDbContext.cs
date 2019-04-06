using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;

namespace University.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();


        }

        public DbSet<Department>Departments { get; set; }
        public DbSet<Instructor>Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
