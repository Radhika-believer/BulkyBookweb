using BulkyBookweb.data;
using BulkyBookweb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyBookweb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly applicationDbcontext _db;
        private applicationDbcontext db;
        private object categoryFromDb;

        public object ModelStatae { get; private set; }

        public CategoryController(applicationDbcontext _db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<category> objcategorylist = _db.categories;
            return View(objcategorylist);
        }
        //Get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(category obj)
        {
            if (obj.Name == obj.Displayorder.ToString())
            {
                ModelState.AddModelError("Nmae", "the displayorder cannot exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["sucess"] = "category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryfromDb = _db.categories.Find(id);
            // var categoryFromDb = _db.categories.FirstOrDefault(u =>u.Id == id);
            //var categoryFromDb = _db.categories.SingleOrDefault(u => u.Id == id);
            return View();
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(category obj)
        {
            if (obj.Name == obj.Displayorder.ToString())
            {
                ModelState.AddModelError("Nmae", "the displayorder cannot exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["sucess"] = "category update succcessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryfromDb = _db.categories.Find(id);
            // var categoryFromDb = _db.categories.FirstOrDefault(u =>u.Id == id);
            //var categoryFromDb = _db.categories.SingleOrDefault(u => u.Id == id);
            return View();
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.categories.Remove(obj);
            _db.SaveChanges();
            TempData["sucess"] = "category deleted succcessfully";
            return RedirectToAction("Index");
        }
    }
}
