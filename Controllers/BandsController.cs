using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using static BANDS.Models.IdentityModel;
using BANDS.Models.ViewModel;
using BANDS.Models;

namespace BANDS.Controllers
{
    public class BandsController : Controller
    {

        private ApplicationDbContext _context;

        public BandsController()
        {

            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        
        // GET: Band
        public ActionResult Index()
        {
            var bands = _context.Bands.ToList();
            return View(bands);


        }



        public ActionResult Details(int id)
        {

            var band = _context.Bands.SingleOrDefault(b => b.Id == id);

            var member = _context.Members.Where(b => b.BandId == id).ToList();


            var schedules = _context.EventSchedules.Where(e => e.BandId == id).ToList();
            List<int> eventIds = new List<int>();



            foreach (var scheduleObj in schedules)
            {
         
                eventIds.Add(scheduleObj.EventId);
            }


            var events = _context.Events.Where(e => eventIds.Contains(e.Id)).ToList();


            //var eve = _context.Events.SingleOrDefault(e => e.Id == id);
            //var schedule = _context.EventSchedules.Include(e => e.Event).Where(e => e.BandId == id).ToList();
     
                   
            var viewModel = new BandViewModel
            {
                Band = band,
                Members = member,
               Events=events,
              //EventSchedule=Schedule is not call beacause Eventschedule bata event liyesakyo n now events call


            };
            return View(viewModel);


        }

        public ActionResult BandForm()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var band = _context.Bands.SingleOrDefault(b => b.Id == id);


            return View("BandForm", band);

        }

        public ActionResult Delete(int id)
        {
            var band=_context.Bands.SingleOrDefault(b=>b.Id == id);
            _context.Bands.Remove(band);
            _context.SaveChanges();
            
            return RedirectToAction("Index", band);

        }

        public ActionResult Save(Band band)

        {
            if(band.Id == 0)
           {
                var id = _context.Bands.Max(b => b.Id);
                band.Id = ++id;
                _context.Bands.Add(band);
                
            }
            else
            {
                var bandDb = _context.Bands.FirstOrDefault(b => b.Id == band.Id);
                bandDb.Name = band.Name;
                bandDb.Country = band.Country;
                bandDb.Genre = band.Genre;
                bandDb.EstDAte = band.EstDAte;
                bandDb.Photo = band.Photo;
            }

            _context.SaveChanges();
            return RedirectToAction("Index","Bands");
        }

    }
}


    

