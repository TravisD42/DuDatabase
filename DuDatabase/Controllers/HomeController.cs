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
        public IActionResult HandleNewCommittee(string name, float budget)
        {
            Committee newCommittee = new Committee() { Name = name, Budget = budget};
            context.Committees.Add(newCommittee);
            context.SaveChanges();

            return RedirectToAction("AddCommittee");
        }

        public IActionResult CommitteeHasMembers()
        {
            List<Object> memberNames = new List<Object>();
            List<Object> committeeNames = new List<Object>();
            List<Object> listofMembers = new List<Object>();
            List<Object> listofComm = new List<Object>();

            var allMembers = context.Members.Include(member => member.CommitteehasMembers).ToList();
            foreach (Member member in allMembers)
            {
                memberNames.Add(member);
            }

            var allCommittees = context.Committees.Include(committee => committee.CommitteehasMembers).ToList();
            foreach(Committee committee in allCommittees)
            {
                committeeNames.Add(committee);
            }

            ViewData["memberNames"] = memberNames;
            ViewData["committeeNames"] = committeeNames;

            return View();
        }

        [HttpPost]
        public IActionResult HandleMembertoCommittee(int memberId, int committeeId)
        {
            Committee exisitngCommittee = context.Committees.Where(committee => committee.Id == committeeId).Single();
            Member existingMember = context.Members.Where(member => member.Id == memberId).Single();
            CommitteehasMembers newMem = new CommitteehasMembers() { MemberId = memberId, CommitteeId = committeeId };
            context.CommitteehasMembers.Add(newMem);
            context.SaveChanges();

            return RedirectToAction("CommitteeHasMembers");
        }

        public IActionResult AddTransaction()
        {
            var allCommittees = context.Committees.Include(committee => committee.Transactions).ToList();
            return View(allCommittees);
        }

        [HttpPost]
        public IActionResult HandleNewTransaction(int committeeId, float amountSpent, float amountAdded)
        {
            Committee existingCommittee = context.Committees.Where(committee => committee.Id == committeeId).Single();
            Transaction newTrans = new Transaction() { Committee = existingCommittee, AmountSpent = amountSpent, AmountAdded = amountAdded };
            existingCommittee.Budget = (existingCommittee.Budget - newTrans.AmountSpent) + newTrans.AmountAdded;
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
