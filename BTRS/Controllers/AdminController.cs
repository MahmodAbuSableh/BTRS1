using BTRS.Data;
using BTRS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTRS.Controllers
{
    public class AdminController : Controller
    {
        private SystemDbContext _context;

        public AdminController(SystemDbContext context)
        {
            this._context = context;
        }


        // GET: AdminController
        public ActionResult TrpsList()
        {
            List<Trip> trips=_context.Trips.ToList();
            return View(trips);
        }

        [HttpGet]
        // GET: AdminController/Details/5
        public ActionResult trpDetails(int id)
        {
            Trip trip = _context.Trips.Find(id);
            return View(trip);
        }

        // GET: AdminController/Create
        [HttpGet]
        public ActionResult trpCreate()
        {
            ViewBag.Busses = _context.Buses.ToList();
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult trpCreate(Trip trip)
        {
            
                int adminId = (int)HttpContext.Session.GetInt32("adminID");
            
                Admin admin = _context.Admins.Where(
                  a => a.Id == adminId
                  ).FirstOrDefault();

            
                trip.Admin = admin;
                
                _context.Trips.Add(trip);
                _context.SaveChanges();

                return RedirectToAction("TrpsList");
            
        }

        // GET: AdminController/Edit/5
        [HttpGet]
        public ActionResult trpEdit(int id)
        {
            ViewBag.Busses = _context.Buses.ToList();
            Trip trip= _context.Trips.Find( id );
            return View(trip);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult trpEdit(int id, Trip trip)
        {
            try
            {
                _context.Trips.Update(trip);
                _context.SaveChanges();
                return RedirectToAction("TrpsList");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        [HttpGet]
        public ActionResult trpDelete(int id)
        {
            Trip trip = _context.Trips.Find(id);
            return View(trip);
         
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult trpDelete(int id, Trip trip)
        {
            try
            {
                _context.Trips.Remove(trip);
                _context.SaveChanges();
                return RedirectToAction("TrpsList");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult BussList()
        {
            List<Buss> busses = _context.Buses.ToList();
            return View(busses);
        }

        [HttpGet]
        // GET: AdminController/Details/5
        public ActionResult bussDetails(int id)
        {
            Buss buss = _context.Buses.Find(id);
            return View(buss);
        }

        // GET: AdminController/Create
        [HttpGet]
        public ActionResult bussCreate()
        {
            ViewBag.trip = _context.Trips.ToList();
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult bussCreate(IFormCollection form)
        {
            
            string capName = form["CapName"];
            int SeatsNumber = int.Parse(form["SeatsNumber"]);
            int tripID = int.Parse(form["tripId"]);
            int adminId = (int)HttpContext.Session.GetInt32("adminID");

            Buss buss = new Buss();
            buss.CapName = capName;
            buss.SeatsNumber = SeatsNumber;
            buss.Trip = _context.Trips.Find(tripID);
            buss.Admin = _context.Admins.Find(adminId);
                
            _context.Buses.Add(buss);
            _context.SaveChanges();

                

            return RedirectToAction("BussList");
            
        }

        // GET: AdminController/Edit/5
        [HttpGet]
        public ActionResult bussEdit(int id)
        {
            ViewBag.trip = _context.Trips.ToList();
            Buss buss = _context.Buses.Find(id);
            return View(buss);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult bussEdit(int id, Buss buss)
        {
            try
            {
                _context.Buses.Update(buss);
                _context.SaveChanges();
                return RedirectToAction("BussList");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        [HttpGet]
        public ActionResult bussDelete(int id)
        {
            Buss buss = _context.Buses.Find(id);
            return View(buss);
           
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult bussDelete(int id, Buss buss)
        {
            try
            {
                _context.Buses.Remove(buss);
                _context.SaveChanges();
                return RedirectToAction("BussList");
            }
            catch
            {
                return View();
            }
        }
    }
}
