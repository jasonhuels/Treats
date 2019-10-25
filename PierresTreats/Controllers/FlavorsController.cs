using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PierresTreats.Controllers
{
    public class FlavorsController : Controller
    {
        private readonly PierresTreatsContext _db;
        public FlavorsController(PierresTreatsContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Flavor> model = _db.Flavors.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Flavor flavor)
        {
            _db.Flavors.Add(flavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisFlavor = _db.Flavors.Include(flavor => flavor.Treats).ThenInclude(join => join.Treat).FirstOrDefault(flavor => flavor.FlavorID == id);
            return View(thisFlavor);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
             var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorID == id);
             return View(thisFlavor);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Flavor flavor)
        {
            _db.Entry(flavor).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize]
        public ActionResult AddTreat(int id)
        {
            var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorID == id);
            ViewBag.TreatID = new SelectList(_db.Treats, "TreatID", "Name");
            return View(thisFlavor);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddTreat(Flavor flavor, int TreatID)
        {
            if (TreatID != 0)
            {
                _db.FlavorTreats.Add(new FlavorTreat() { TreatID = TreatID, FlavorID = flavor.FlavorID });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorID == id);
            return View(thisFlavor);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorID == id);
            _db.Flavors.Remove(thisFlavor);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteTreat(int joinID)
        {
            var joinEntry = _db.FlavorTreats.FirstOrDefault(entry => entry.FlavorTreatID == joinID);
            _db.FlavorTreats.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}