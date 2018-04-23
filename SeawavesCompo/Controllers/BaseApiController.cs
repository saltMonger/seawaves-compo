using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using SeawavesCompo.DataAccess;
using SeawavesCompo.Models;

namespace SeawavesCompo.Controllers
{
    public class BaseApiController : ApiController
    {

        protected readonly ApplicationUserManager manager;
        protected readonly ApplicationDbContext applicationDb = new ApplicationDbContext();
        protected SeaWavesDBEntities db { get; set; }

        public BaseApiController()
        {
            db = new SeaWavesDBEntities();
            manager = new ApplicationUserManager(new UserStore<ApplicationUser>(applicationDb));
        }
    }
}
