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
        public async Task<IActionResult> Index(string SortOrder, string SortBy)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;

            var department = await _db.Departments.ToListAsync();


            switch (SortBy)
            {

                case "DepartmentId":
                    switch (SortOrder)
                    {
                        case "Asc":
                            department = department.OrderBy(x => x.DepartmentId).ToList();
                            break;

                        case "Desc":
                            department = department.OrderByDescending(x => x.DepartmentId).ToList();
                            break;

                        default:
                            break;
                    }

                    break;

                case "DepartmentName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            department = department.OrderBy(x => x.DepartmentName).ToList();
                            break;

                        case "Desc":
                            department = department.OrderByDescending(x => x.DepartmentName).ToList();
                            break;

                        default:
                            break;
                    }

                    break;

                default:
                    department = department.OrderBy(x => x.DepartmentId).ToList();
                    break;

            }


            return View(department);
        }



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