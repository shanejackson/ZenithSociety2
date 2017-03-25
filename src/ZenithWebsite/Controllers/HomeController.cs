using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace ZenithWebsite.Controllers
{
    public class HomeController : Controller
    {
        private const string FORMAT = "MMMM dd, yyyy";
        private ZenithContext db;

        public HomeController(ZenithContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var @event = db.Events.Include(that => that.Activity);

            Dictionary<String, List<Models.Event>> Week = new Dictionary<String, List<Event>>();

            //Find the monday of this week
            DateTime today = DateTime.Now;
            int range = DayOfWeek.Monday - today.DayOfWeek;
            if (range > 0)
                range -= 7; // Always get this weeks dates
            DateTime monday = today.Date.AddDays(range);
            DateTime nextMonday = monday.AddDays(7);
            ViewBag.StartOfWeek = monday.ToString(FORMAT);

            //Allow only days this week
            var daysOfTheWeek = @event.Where(e => e.EventFrom >= monday && e.EventTo < nextMonday);

            //add to dictionary
            foreach (var e in daysOfTheWeek.OrderBy(name => name.EventFrom).ToList())
            {
                if (e.IsActive)
                {
                    if (Week.ContainsKey(e.EventFrom.ToString(FORMAT)))
                    {

                        Week[e.EventFrom.ToString(FORMAT)].Add(e);
                    }
                    else
                    {
                        Week[e.EventFrom.ToString(FORMAT)] = new List<Event> { e };
                    }
                }
            }

            ViewBag.Week = Week.ToList();

            return View();
        }
    
        public IActionResult Error()
        {
            return View();
        }
    }
}
