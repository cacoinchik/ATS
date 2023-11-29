using ATS.Data;
using ATS.Models;
using ATS.Models.ViewModels;
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
            var debts = db.Debts.Include(x => x.Subscriber).ToList();
            return View(debts);
        }


        //подробная инфа об абоненте
        public IActionResult SubInformation(int id)
        {
            var sub = db.Subscribers.Include(x => x.Phones).Include(x => x.Debts).FirstOrDefault(x => x.Id == id);
            if (sub == null)
                return NotFound();
            return View(sub);
        }

        [HttpGet]
        public IActionResult SubAdd()
        {
            SubscriberAddVM model = new SubscriberAddVM();
            return View(model);
        }

        [HttpPost]
        public IActionResult SubAdd(SubscriberAddVM model)
        {
            if (ModelState.IsValid)
            {
                var sub = new Subscriber
                {
                    Surname = model.Surname,
                    Name = model.Name,
                    Patronymic = model.Patronymic,
                    Email = model.Email
                };
                db.Subscribers.Add(sub);
                db.SaveChanges();
                return Redirect("/");
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult PhoneAdd(int id)
        {
            PhoneAddVM model = new PhoneAddVM();
            model.SubscriberId = id;
            return View(model);
        }

        [HttpPost]
        public IActionResult PhoneAdd(PhoneAddVM model)
        {
            if (ModelState.IsValid)
            {
                var phone = new Phone
                {
                    PhoneModel = model.PhoneModel,
                    PhoneNumber = model.PhoneNumber,
                    SubscriberId = model.SubscriberId
                };
                db.Phones.Add(phone);
                db.SaveChanges();
                return Redirect("/");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult DebAdd(int id)
        {
            DebtsAddVM model = new DebtsAddVM();
            model.SubscriberId = id;
            return View(model);
        }

        [HttpPost]
        public IActionResult DebAdd(DebtsAddVM model)
        {
            if (ModelState.IsValid)
            {
                var deb = new Debts
                {
                    Name = model.Name,
                    Amount = model.Amount,
                    SubscriberId = model.SubscriberId
                };
                db.Debts.Add(deb);
                db.SaveChanges();
                return Redirect("/");
            }
            return View(model);
        }
    }
}
