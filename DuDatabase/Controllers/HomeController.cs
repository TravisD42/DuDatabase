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

        [HttpPost]
        public IActionResult HandleNewMember(string firstName, string lastName, string email, string phone, float amount, string paymentPlan, float serviceHours, float fundraising)
        {
            Member newMember = new Member() { FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = phone, Amount = amount, PaymentPlan = paymentPlan, ServiceHours = serviceHours, Fundraising = fundraising };
            context.Members.Add(newMember);
            context.SaveChanges();

            return RedirectToAction("AddMember");
        }

        public IActionResult AddCommittee()
        {
            return View(context.Committees.ToList());
        }

        [HttpPost]
        public IActionResult HandleNewCommittee(string name, float budget, float moneyRaised)
        {
            Committee newCommittee = new Committee() { Name = name, Budget = budget, MoneyRaised = moneyRaised };
            context.Committees.Add(newCommittee);
            context.SaveChanges();

            return RedirectToAction("AddCommittee");
        }

        public IActionResult CommitteeHasMembers()
        {
            return View(context.CommitteehasMembers.ToList());
        }

        public IActionResult AddTransaction()
        {
            var allCommittees = context.Committees.Include(committee => committee.Transactions).ToList();
            return View(allCommittees);
        }

        [HttpPost]
        public IActionResult HandleNewTransaction(float amountSpent, float amountAdded)
        {
            Transaction newTrans = new Transaction() { AmountSpent = amountSpent, AmountAdded = amountAdded };
            context.Transactions.Add(newTrans);
            context.SaveChanges();

            return RedirectToAction("AddTransaction");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
