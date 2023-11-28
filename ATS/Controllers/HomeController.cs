using ATS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace ATS.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext db;
        public HomeController(AppDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index() => View();

        //список абонентов
        [HttpGet]
        public IActionResult Subscribers()
        {
            var subscribers = db.Subscribers.ToList();
            return View(subscribers);
        }

        //список телефонов
        [HttpGet]
        public IActionResult Phones()
        {
           var phones = db.Phones.Include(x => x.Subscriber).ToList();
           return View(phones);
        }

        //список долгов
        [HttpGet]
        public IActionResult Debts()
        {
            var debts =db.Debts.Include(x => x.Subscriber).ToList();
            return View(debts);
        }


        //подробная инфа об абоненте
        public IActionResult SubInformation(int id)
        {
            var sub = db.Subscribers.Include(x=>x.Phones).Include(x=>x.Debts).FirstOrDefault(x=>x.Id == id);
            if (sub == null)
                return NotFound();
            return View(sub);
        }
    }
}
