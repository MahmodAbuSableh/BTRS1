using BTRS.Data;
using BTRS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BTRS.Controllers
{
    public class HomeController : Controller
    {
        private SystemDbContext _context;

        public HomeController(SystemDbContext context)
        {
            this._context = context;
        }
        public bool checkUsername(string username)
        {
            

            Passenger passenger = _context.Passengers.Where(u => u.Username.Equals(username)).FirstOrDefault();
            if (passenger != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool checkEmail(string email)
        {


            Passenger passenger = _context.Passengers.Where(u => u.Email.Equals(email)).FirstOrDefault();
            if (passenger != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkPhoneNumber(string phonenumber )
        {


            Passenger passenger = _context.Passengers.Where(u => u.PhoneNumber.Equals(phonenumber)).FirstOrDefault();
            if (passenger != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkEmpty(Passenger passenger)
        {
            if (String.IsNullOrEmpty(passenger.Username)) return false;
            else if (String.IsNullOrEmpty(passenger.Password)) return false;
            else if (String.IsNullOrEmpty(passenger.Name)) return false;
            else return true;
        }
        
        
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            ViewBag.HideNavbar = true;
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Passenger passenger)
        {

            bool empty = checkEmpty(passenger);
            bool duplicat = checkEmail(passenger.Email);
            bool duplicat2 = checkUsername(passenger.Username);
            bool duplicat3 = checkPhoneNumber(passenger.PhoneNumber);
            if (empty)
            {
                if (duplicat)
                {
                    if (duplicat2)
                    {
                        if (duplicat3)
                        {
                            _context.Passengers.Add(passenger);
                            _context.SaveChanges();
                            TempData["Msg"] = "the data was saved";

                            return View();
                        }
                        else
                        {
                            TempData["Msg"] = "please change PhoneNumber";

                            return View();

                        }
                    }
                    else
                    {
                        TempData["Msg"] = "please change Username";

                        return View();

                    }
                }

                else
                {
                    TempData["Msg"] = "please change Email";

                    return View();
                }
            }
            else
            {
                TempData["Msg"] = "Please fill all input";
                return View();
            }


        }



    





        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.HideNavbar = true;
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login userlogin)
        {
            if (ModelState.IsValid)
            {
                string username = userlogin.username;
                string password = userlogin.password;

                Passenger passenger = _context.Passengers.Where(
                     u => u.Username.Equals(username) &&
                     u.Password.Equals(password)
                     ).FirstOrDefault();

                Admin admin = _context.Admins.Where(
                    a => a.Username.Equals(username)
                    &&
                    a.Password.Equals(password)
                    ).FirstOrDefault();




                if (passenger != null)
                {
                    HttpContext.Session.SetInt32("passID", passenger.Id);

                    return RedirectToAction("Index","Passenger");
                }
                else if (admin != null)
                {

                    HttpContext.Session.SetInt32("adminID", admin.Id);

                    return RedirectToAction("TrpsList", "Admin");
                }
                else
                {
                    TempData["Msg"] = "The user Not Found";
                }


            }
            else
            {

            }
            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
