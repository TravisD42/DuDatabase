using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DuDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace DuDatabase.Controllers
{
    public class HomeController : Controller
    {
        private DeltaUpsilonContext context;

        public HomeController(DeltaUpsilonContext c)
        {
            context = c;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMember()
        {
            return View(context.Members.ToList());
        }

        public IActionResult AddDues()
        {
            var allDues = context.Dues.Include(member => member.Member).ToList();
            return View(allDues);
        }

        [HttpPost]
        public IActionResult HandleNewMember(string firstName, string lastName, string email, string phone)
        {
            Member newMember = new Member() { FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = phone };
            context.Members.Add(newMember);
            context.SaveChanges();

            return RedirectToAction("AddMember");
        }

        [HttpPost]
        public IActionResult HandleNewDues(int memberId, float amount, string paymentPlan, float serviceHours, float fundraising)
        {
            Member existingMember = context.Members.Where(existingMem => existingMem.Id == memberId).Single();
            Dues newDues = new Dues() { Member = existingMember, Amount = amount, PaymentPlan = paymentPlan, ServiceHours = serviceHours, Fundraising = fundraising};
            context.Dues.Add(newDues);
            context.SaveChanges();

            return RedirectToAction("AddDues");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
