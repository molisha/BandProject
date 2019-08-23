using BANDS.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


using static BANDS.Models.IdentityModel;
using BANDS.Models;

namespace BANDS.Controllers
{
    public class EventsController : Controller
    {

        private ApplicationDbContext _context;

        public EventsController()
        {

            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: Events


        public ActionResult Index(String search)
        {
            {
               
                    var events=_context.Events.Where(x => x.Venue.StartsWith(search) || search == null || x.EventTitle.StartsWith(search)).ToList(); 
                
                    

                return View(events);
            }
            

            


        }


        public ActionResult Saves(Event events)

        {
            if (events.Id == 0)
            {
                var id = _context.Events.Max(e => e.Id);
                events.Id = ++id;
                _context.Events.Add(events);

                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Events");


        }

        public ActionResult EventDetails(int id)
        {
            //var schedule = _context.EventSchedules.Include(c => c.Band).Include(c => c.Event).Where(e => e.EventId == id).ToList();

            var eve = _context.Events.SingleOrDefault(e => e.Id == id);
            // 
            var schdedule = _context.EventSchedules.Include(c => c.Band).Where( e => e.Event.Id == id).ToList();
            
            var viewModel = new EventViewModel
            {

                Event = eve,
                EventSchedule = schdedule

            };
            return View(viewModel);

        }

            public ActionResult EventForm()
            {
                return View();
            }



    

    }

}

          
