using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDb.Data;
using StudentDb.Models;

namespace StudentDb.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseDbContext _context;
        public CourseController(CourseDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Course>CourseList = _context.Courses;
            return View(CourseList);
        }
    }
}
