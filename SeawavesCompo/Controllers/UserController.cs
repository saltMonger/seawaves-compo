using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SeawavesCompo.Models;
using SeawavesCompo.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SeawavesCompo.Controllers
{
    public class UserController : Controller
    {
        private readonly SeawavesCompo.DataAccess.SeaWavesDBEntities db = new DataAccess.SeaWavesDBEntities();
        private readonly ApplicationDbContext applicationDb = new ApplicationDbContext();
        private readonly ApplicationUserManager manager;

        public UserController()
        {
            manager = new ApplicationUserManager(new UserStore<ApplicationUser>(applicationDb));
        }

        //public UserController(SeawavesCompo.DataAccess.SeaWavesDBEntities context)
        //{
        //    db = context;
        //    manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        //}

        // GET: User
        [Authorize]
        public async Task<ActionResult> Index()
        {
            //need to get user, and then make a view based off of that
            //USER level users will see their user profile
            //ADMIN level users will see a list of users/manager stuff
            var user = await manager.FindByIdAsync(User.Identity.GetUserId());
            if (!manager.IsInRole(user.Id, "ADMIN"))
            {
                var usermodel = db.Users.FirstOrDefault(u => u.UserID.Equals(user.Id));
                return RedirectToAction("UserPage", "User", new { id = user.Id });
            }
            //grab all users
            var users = db.Users.ToList();
            return View(users);
        }

        [Authorize]
        public async Task<ActionResult> UserPage(string id)
        {
            //if the user is the owner of this id (current user id == id), then
            //they can edit the page using AJAX
            var user = await manager.FindByIdAsync(User.Identity.GetUserId());
            var userobj = db.Users.FirstOrDefault(u => u.UserID.Equals(user.Id));
            ViewBag.AbleToEditPage = (userobj.UserID == User.Identity.GetUserId());
            var usermodel = new UserProfileFullModel
            {
                ID = userobj.Id,
                ProfileText = userobj.ProfileText,
                VaporAmount = userobj.VaporAmount,
                AetherAmount = userobj.AetherAmount,
                UserHandle = userobj.UserHandle,
                Avatar = userobj.Avatar
            };

            return View(usermodel);
        }

    }
}