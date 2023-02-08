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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if(ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("Index");  
            }
            return View(course);
        }
        public IActionResult Edit(int? Id)
        {
            var info = _context.Courses.Find(Id);
            if (info == null)
            {
                return NotFound();

            }
           
            return View(Id);
        }
        [HttpPost]
        public IActionResult Edit(Course courses)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Update(courses);
                _context.SaveChanges(true);
                return RedirectToAction("Index");
            }
            return View(courses);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteCourse(int? id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Courses.Remove();
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

    }
}
