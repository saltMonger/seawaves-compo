using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SeawavesCompo.DataAccess;
using SeawavesCompo.Models;
using SeawavesCompo.Models.CompetitionModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SeawavesCompo.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly SeawavesCompo.DataAccess.SeaWavesDBEntities db = new DataAccess.SeaWavesDBEntities();
        private readonly ApplicationDbContext applicationDb = new ApplicationDbContext();
        private readonly ApplicationUserManager manager;

        public CompetitionController()
        {
            manager = new ApplicationUserManager(new UserStore<ApplicationUser>(applicationDb));
        }

        // GET: Competition
        public ActionResult Index()
        {
            var comps = db.Competitions.ToList();
            return View(comps);
        }

        public async Task<ActionResult> Host()
        {
            //TODO: need to do checking to see if there are enough free hosts
            //or vapor left

            //get host user id
            //var user = db.Users.FirstOrDefault(u=> u.UserID.Equals(manager.FindByIdAsync(User.Identity.GetUserId()).Id));

            return View();
        }

        public async Task<ActionResult> Compete(string id)
        {
            Competition comp = db.Competitions.Include(c => c.CompoPacks).FirstOrDefault(c => c.Id == id);

            if((CompetitionPhase)comp.CurrentPhase != CompetitionPhase.ACTIVE)
            {
                return RedirectToAction(Url.Action("View", new { id = id }));
            }

            return View(comp);
        }

        public async Task<ActionResult> Vote(string id)
        {
            var comp = db.Competitions.Include(c => c.Entries.Select(y => y.User)).Include(c => c.CompoPacks).FirstOrDefault(c => c.Id == id);

            if ((CompetitionPhase)comp.CurrentPhase != CompetitionPhase.VOTE){
                return RedirectToAction(Url.Action("View", new { id = id }));
            }

            return View(comp);
        }

        public async Task<ActionResult> View(string id)
        {
            //holy shit
            //var comp = db.Competitions.FirstOrDefault(c => c.Id == id);
            //var comp = db.Competitions.Include(x => x.User).FirstOrDefault(c => c.Id == id);
            var comp = db.Competitions.Include(c => c.Entries.Select(y => y.User)).Include(c => c.CompoPacks).FirstOrDefault(c => c.Id == id);
            
            //entries, need users on those entries

            if((CompetitionPhase)comp.CurrentPhase != CompetitionPhase.ENDED)
            {
                return RedirectToAction(Url.Action("Index"));
            }
            ViewBag.Entries = db.Entries.Where(e => e.CompetitionID == id);
            ViewBag.CompoPack = db.CompoPacks.FirstOrDefault(c => c.CompetitionID == id);
            return View(comp);
        }
    }
}