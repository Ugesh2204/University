using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;

namespace University.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get Action
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            ViewBag.CurrentPage = 1;
            ViewBag.LastPage = Math.Ceiling(Convert.ToDouble(_db.Departments.ToList().Count) / 5);
            var department = await _db.Departments.ToListAsync();

            return View(department.Take(5));
        }

        [HttpPost]
        public ActionResult Index(int CurrentPage, int LastPage)
        {
            ViewBag.CurrentPage = CurrentPage;
            ViewBag.LastPage = LastPage;
            return View(_db.Departments.OrderBy(x => x.DepartmentId).Skip((CurrentPage - 1) * 5).Take(5));
        }


        //To whole the value 













        //Get Departments

        [HttpGet]
        public IActionResult CreateDpt()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateDpt(Department Dpt)
        {
            if (ModelState.IsValid)
            {
                _db.Add(Dpt);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(Dpt);
        }



        //Get Detail// single id 

        public async Task<IActionResult> Detail(int? id)
        {

            var department = await _db.Departments.SingleOrDefaultAsync(x => x.DepartmentId == id);
            return View(department);
        }



        //Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _db.Departments.SingleOrDefaultAsync(x => x.DepartmentId == id);
            return View(department);

        }


        [HttpPost]
        public async Task<IActionResult> Edit(Department Dpt)
        {
            if (ModelState.IsValid)
            {
                _db.Update(Dpt);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        //Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _db.Departments.SingleOrDefaultAsync(x => x.DepartmentId == id);
            return View(department);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _db.Departments.SingleOrDefaultAsync(x => x.DepartmentId == id);
            _db.Departments.Remove(department);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}