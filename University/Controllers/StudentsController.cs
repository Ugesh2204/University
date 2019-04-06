using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using University.Data;
using University.Models;

namespace University.Controllers
{
    public class StudentsController : Controller
    {

        private readonly ApplicationDbContext schoolDbContext;

        public StudentsController(ApplicationDbContext _schoolDbContext)
        {
            schoolDbContext = _schoolDbContext;
        }

        public IActionResult Index()
        {
            var students = schoolDbContext.Students.ToList();
            return View(students);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = schoolDbContext.Students.Find(id);
            schoolDbContext.Remove<Student>(student);
            schoolDbContext.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult AjaxDelete(int id)
        {
            var student = schoolDbContext.Students.Find(id);
            schoolDbContext.Remove<Student>(student);
            schoolDbContext.SaveChanges();
            var students = schoolDbContext.Students;
            return PartialView(students);
        }


    }
}