using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WineTravelBlog.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WineTravelBlog.Controllers
{
    public class RegionsController : Controller
    {
        // GET: /<controller>/
        private WineBlogDbContext db = new WineBlogDbContext();
        public IActionResult Index()
        {
            return View(db.Regions.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisRegion = db.Regions.FirstOrDefault(regions => regions.RegionId == id);
            return View(thisRegion);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Region region)
        {
            db.Regions.Add(region);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisRegion = db.Regions.FirstOrDefault(regions => regions.RegionId == id);
            return View(thisRegion);
        }

        [HttpPost]
        public IActionResult Edit(Region item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisRegion = db.Regions.FirstOrDefault(regions => regions.RegionId == id);
            return View(thisRegion);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisRegion = db.Regions.FirstOrDefault(regions => regions.RegionId == id);
            db.Regions.Remove(thisRegion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

