using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using University.Data;
using University.Models;

namespace University.Controllers
{
    public class InstructorsController : Controller
    {
        ApplicationDbContext _db;


        public InstructorsController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var instructors = _db.Instructors.ToList();
            return View(instructors);

        }




        [HttpGet]
        public IActionResult AjaxDelete(int id)
        {
            var instructor = _db.Instructors.Find(id);
            _db.Remove<Instructor>(instructor);
            _db.SaveChanges();
            var instructors = _db.Instructors.ToList(); ;
            return PartialView(instructors);
        }
    }
}