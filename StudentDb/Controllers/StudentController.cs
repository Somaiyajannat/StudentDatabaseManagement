using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using StudentDb.Data;
using StudentDb.Models;

namespace StudentDb.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _context;
        public StudentController(StudentDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> studnetList = _context.Studnets.ToList();
            return View(studnetList);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if(ModelState.IsValid)
            {
                _context.Studnets.Add(student);
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Succfully";
                return RedirectToAction("Index");
            }
            return View(student);
            
        }
        
        public IActionResult Edit(int? Id)
        {
            var info = _context.Studnets.Find(Id);
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            if(info == null)
            {
                return NotFound();
            }
            return View(info);
        
      
        }
        [HttpPost]

        public IActionResult Edit(Student student)
        {
            if(ModelState.IsValid)
            {
                _context.Studnets.Update(student);
                _context.SaveChanges();
                TempData["ResultOk"] = "Data Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var deleteInfo = _context.Studnets.Find(Id);
            if (deleteInfo == null)
            {
                return NotFound();
            }
            return View(deleteInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStudent(int? Id)
        {
            var deleteInfo = _context.Studnets.Find(Id);
            if(deleteInfo == null)
            {
                return NotFound();
            }
            else
            {
                _context.Studnets.Remove(deleteInfo);
                _context.SaveChanges();
                TempData["ResultOk"] = "Data Deleted Successfully";
                return RedirectToAction("Index");
            }
        }
    }
}
