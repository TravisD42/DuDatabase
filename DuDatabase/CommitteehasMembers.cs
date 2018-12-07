using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuDatabase.Models
{
    public class CommitteehasMembers
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int CommitteeId { get; set; }
        public Committee Committee { get; set; }
    }
}
