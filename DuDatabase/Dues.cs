using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuDatabase.Models
{
    public class Dues
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public string PaymentPlan { get; set; }
        public float ServiceHours { get; set; }
        public float Fundraising { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
