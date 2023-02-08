using Microsoft.EntityFrameworkCore;
using StudentDb.Models;

namespace StudentDb.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options): base(options)
        {

        }
        public DbSet<Student> Studnets { get; set; }
    }
}
