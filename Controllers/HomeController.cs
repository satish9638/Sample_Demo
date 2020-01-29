using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample_Test.Data;
using Sample_Test.Models;

namespace Sample_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBuyerRepository _buyerRepository;
        private readonly IEventRepository _eventRepository;
        DateTime eventDate = new DateTime();
        public HomeController(
            ILogger<HomeController> logger,
            IBuyerRepository buyerRepository,
            IEventRepository eventRepository)
        {
            _logger = logger;
            _buyerRepository = buyerRepository;
            _eventRepository = eventRepository;
        }

        public async Task<IActionResult> Index()
        {
            var defaultEvent = await _eventRepository.GetDefaultEvent();
            if (defaultEvent != null)
            {
                eventDate = DateTime.Now.AddSeconds(defaultEvent.TimeoutInSeconds);
            }
            else
            {
                eventDate = DateTime.Now.AddSeconds(50);
            }
            ViewData["eventDate"] = eventDate.ToString("yyyy-MM-dd HH:mm:ss");
            ViewData["ticketStatus"] = "Time Expired";

            return View();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Save(Buyer buyer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewData["eventDate"] = DateTime.Now.AddSeconds(50).ToString("yyyy-MM-dd HH:mm:ss");
        //        return View("index");
        //    }
        //    //buyer.EventId = 1;
        //    buyer.TesterKey = "satishmiroliya14";
        //    ViewData["eventDate"] = eventDate;

        //    if (buyer != null)
        //    {
        //        var retval = await _buyerRepository.InsertBuyerAsync(buyer);
        //        ViewBag.EventAdded = "1";
        //        ViewData["ticketStatus"] = "Ticket Bought";
        //        return View("index");
        //    }

        //    return View("index");
        //}

        [HttpPost]
        public async Task<JsonResult> SaveEvent(Buyer buyer)
        {
            if (!ModelState.IsValid)
            {
                ViewData["eventDate"] = DateTime.Now.AddSeconds(50).ToString("yyyy-MM-dd HH:mm:ss");
                //return View("index");
                return Json(new { success = false, error = "Buyer name is required." });
            }
            buyer.EventId = 1;
            buyer.TesterKey = "satishmiroliya14";
            ViewData["eventDate"] = eventDate;

            if (buyer != null)
            {
                var retval = await _buyerRepository.InsertBuyerAsync(buyer);
                ViewBag.EventAdded = "1";
                ViewData["ticketStatus"] = "Ticket Bought";
                //return View("index");
                return Json(new { success = true, message = "Ticket Bought" });
            }
            return Json(new { success = false, error = "Error in add event." });
            //return View("index");
        }

        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public JsonResult GetByEventId(int eventId)
        {
            var retval = _buyerRepository.GetBuyerByEvent(eventId);
            if (retval != null)
            {
                ViewData["ticketStatus"] = "To Late";
                return Json(new { success = true, message = "To Late" });
            }
            return Json(new { success = false });
        }
    }
}
