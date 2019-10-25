using Microsoft.AspNetCore.Mvc;
using PierresTreats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierresTreats.Controllers
{
    
    public class TreatsController : Controller
    {
        private readonly PierresTreatsContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TreatsController(UserManager<ApplicationUser> userManager, PierresTreatsContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public ActionResult Index()
        {
            List<Treat> model = _db.Treats.Include(treats => treats.Flavors).OrderBy(s => s.Name).ToList();

            return View(model);

        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.FlavorID = new SelectList(_db.Flavors, "FlavorID", "Description");
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(Treat treat, int FlavorID)
        {
            var userID = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userID);
            treat.User = currentUser;
            _db.Treats.Add(treat);
            if(FlavorID != 0)
            {
                _db.FlavorTreats.Add(new FlavorTreat() {FlavorID = FlavorID, TreatID = treat.TreatID});
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisTreat = _db.Treats.Include(treat => treat.Flavors).ThenInclude(join => join.Flavor).FirstOrDefault(treat => treat.TreatID == id);
            return View(thisTreat);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatID == id);
            ViewBag.FlavorID = new SelectList(_db.Flavors, "FlavorID", "Description");
            return View(thisTreat);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Treat treat, int FlavorID)
        {
            if(FlavorID != 0)
            {
                _db.FlavorTreats.Add(new FlavorTreat() {FlavorID = FlavorID, TreatID = treat.TreatID});
            }
            _db.Entry(treat).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult AddFlavor(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatID == id);
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorID", "Description");
            return View(thisTreat);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddFlavor(Treat treat, int FlavorID)
        {
            if (FlavorID != 0)
            {
                _db.FlavorTreats.Add(new FlavorTreat() { FlavorID = FlavorID, TreatID = treat.TreatID });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatID == id);
            return View(thisTreat);
        }


        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisTreat = _db.Treats.FirstOrDefault(treats =>treats.TreatID == id);
            _db.Treats.Remove(thisTreat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteFlavor(int joinID)
        {
            var joinEntry = _db.FlavorTreats.FirstOrDefault(entry => entry.FlavorTreatID == joinID);
            _db.FlavorTreats.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}