using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using static BANDS.Models.IdentityModel;
using BANDS.Models.ViewModel;

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

            var band = _context.Bands.SingleOrDefault(b => b.Id==id);
           
           var member = _context.Members.Where(b => b.BandId == id).ToList();
            var viewModel = new BandViewModel
            {
                Band = band,
                Member = member

            };
            return View(viewModel);

        }


            public ActionResult Edit(int id)
            {
                var band = _context.Bands.SingleOrDefault(b => b.Id == id);
                 

                var viewmodel = new BandViewModel
                {
                    Band = band,
                    Member = _context.Members.ToList()
                };
                return View("BandForm", viewmodel);



              }

        public ActionResult Delete(int id)
        {

            return View();

        }

    }
    }

