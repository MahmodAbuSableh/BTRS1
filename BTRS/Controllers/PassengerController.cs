using Microsoft.AspNetCore.Mvc;
using BTRS.Models;
using Microsoft.EntityFrameworkCore;
using BTRS.Data;

namespace BTRS.Controllers
{
    public class PassengerController : Controller
    {
        private readonly SystemDbContext _context;

        public PassengerController(SystemDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Trip> trips= _context.Trips.ToList();
            return View(trips);
        }

        

        public IActionResult tripList()
        {
            int passID = (int)HttpContext.Session.GetInt32("passID");
            if (passID != 0)
            {
                //List<int> lst_pass_trip = _context.passenger_trip.Where(
                //    p => p.passenger.Id == passID
                //    ).Select(t => t.trip.Id).ToList();
                //List<Teams> lst_teams = _context.teams.Where(
                //    t => lst_user_team.Contains(t.ID) == false).ToList();
                List<Trip> trips = _context.Trips.ToList();
                return View(trips);
            }
            else return NotFound();
        }

        public IActionResult BookTrip(int id)
        {
            int passID = (int)HttpContext.Session.GetInt32("passID");

            Passengers_Trips passengers_Trips = new Passengers_Trips();
            passengers_Trips.passenger = _context.Passengers.Find(passID);
            passengers_Trips.trip = _context.Trips.Find(id);

            _context.passenger_trip.Add(passengers_Trips);
            _context.SaveChanges();

            return RedirectToAction("bookedList");
        }

        public IActionResult bookedList()
        {
            int passID = (int)HttpContext.Session.GetInt32("passID");

            List<int> lst_pass = _context.passenger_trip.Where(
                t => t.passenger.Id == passID).Select(s => s.trip.Id).ToList();

            List<Trip> lst_trip = _context.Trips.Where(
                t => lst_pass.Contains(t.Id)
                ).ToList();

            return View(lst_trip);
        }




        public IActionResult unbookTrip(int id)
        {
            int passID = (int)HttpContext.Session.GetInt32("passID");
            Passengers_Trips passengers_Trips = _context.passenger_trip.Where(
                p => p.passenger.Id == passID && p.trip.Id == id
                ).FirstOrDefault();

            _context.passenger_trip.Remove(passengers_Trips);
            _context.SaveChanges();
            return RedirectToAction("bookedList");
        }
    }
}
