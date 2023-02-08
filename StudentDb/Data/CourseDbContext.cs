using Microsoft.EntityFrameworkCore;
using StudentDb.Models;

namespace StudentDb.Data
{
    public class CourseDbContext:DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
    }
}
