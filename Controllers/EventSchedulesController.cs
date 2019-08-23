using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BANDS.Models.IdentityModel;
using BANDS.Models;
using System.Data.Entity;
using BANDS.Models.ViewModel;

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
        public ActionResult Index(string search)
        {

            //var schedule = _context.EventSchedules.Include(e =>e.Band).Include(e => e.Event).Where(e => e.EventId == id).ToList();
            //filter ma Go garda data dekhauxa
            var schedule = _context.EventSchedules.Where(ev => ev.Band.Name.StartsWith(search) || search == null).Include(e => e.Event).ToList();

            var band = _context.Bands.ToList();

            var viewmodel = new EventScheduleViewModel
            {
                EventSchedule = schedule,

                Band = band
            };
            return View(viewmodel);
        }


        public ActionResult Search(String search, string searchs)

        {
           
            if (search == "Venue")
            {
                //var eventSchedule = _context.EventSchedules.Include(b => b.Band).Include(b => b.Event).Where(b => b.Event.Venue.StartsWith(searcht)).ToList();
                return View( _context.EventSchedules.Include(b => b.Band).Include(b => b.Event).Where(b => b.Event.Venue.StartsWith(searchs)).ToList());
            }
            else if (search == "EventTitle")
            {
                return View(_context.EventSchedules.Include(b => b.Band).Include(b => b.Event).Where(b => b.Event.EventTitle.StartsWith(searchs)).ToList());
            }
            else if (search == "BandName")
            {
                return View(_context.EventSchedules.Include(b => b.Band).Include(b => b.Event).Where(b => b.Band.Name.StartsWith(searchs)).ToList());
            }
            return View(_context.EventSchedules.Include(b => b.Band).Include(b => b.Event).ToList());


        }
    }
    }
