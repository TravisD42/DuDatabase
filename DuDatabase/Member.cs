using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuDatabase.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public float Amount { get; set; }
        public string PaymentPlan { get; set; }
        public float ServiceHours { get; set; }
        public float Fundraising { get; set; }

        public ICollection<CommitteehasMembers> CommitteehasMembers { get; set; } = new List<CommitteehasMembers>();
    }
}
