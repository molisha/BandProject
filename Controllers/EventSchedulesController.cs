using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BANDS.Models.IdentityModel;
using BANDS.Models;
using System.Data.Entity;

namespace BANDS.Controllers
{
    public class EventSchedulesController : Controller
    {
        private ApplicationDbContext _context;

        public EventSchedulesController()
        {

            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: EventSchedules
        public ActionResult Index(int id)
        {
          var schedule = _context.EventSchedules.Include(e =>e.Band).Include(e => e.Event).Where(e => e.EventId == id).ToList();

          

            return View(schedule);
        }
    }
}