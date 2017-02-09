using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WineTravelBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WineTravelBlog.Controllers
{
    public class WinesController : Controller
    {
        private WineBlogDbContext db = new WineBlogDbContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Wines.Include(wines => wines.Winery).ToList());
        }

        public IActionResult Details(int id)
        {
            var thisWine = db.Wines.FirstOrDefault(wines => wines.WineId == id);
            return View(thisWine);
        }

        public IActionResult Create()
        {
            ViewBag.WineryId = new SelectList(db.Wineries, "WineryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Wine wine)
        {
            db.Wines.Add(wine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisWine = db.Wines.FirstOrDefault(wines => wines.WineId == id);
            ViewBag.WineryId = new SelectList(db.Wineries, "WineryId", "Name");
            return View(thisWine);
        }

        [HttpPost]
        public IActionResult Edit(Wine wine)
        {
            db.Entry(wine).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisWine = db.Wines.FirstOrDefault(wines => wines.WineId == id);
            return View(thisWine);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisWine = db.Wines.FirstOrDefault(wines => wines.WineId == id);
            db.Wines.Remove(thisWine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
