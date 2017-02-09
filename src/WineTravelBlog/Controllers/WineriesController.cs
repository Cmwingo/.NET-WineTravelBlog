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

    public class WineriesController : Controller
    {
        private WineBlogDbContext db = new WineBlogDbContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Wineries.Include(wineries => wineries.Region).ToList());
        }

        public IActionResult Details(int id)
        {
            var thisWinery = db.Wineries.FirstOrDefault(wineries => wineries.WineryId == id);
            return View(thisWinery);
        }

        public IActionResult Create()
        {
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Winery winery)
        {
            db.Wineries.Add(winery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisWinery = db.Wineries.FirstOrDefault(wineries => wineries.WineryId == id);
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "Name");
            return View(thisWinery);
        }

        [HttpPost]
        public IActionResult Edit(Winery winery)
        {
            db.Entry(winery).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisWinery = db.Wineries.FirstOrDefault(wineries => wineries.WineryId == id);
            return View(thisWinery);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisWinery = db.Wineries.FirstOrDefault(wineries => wineries.WineryId == id);
            db.Wineries.Remove(thisWinery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
