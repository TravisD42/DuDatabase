﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuDatabase.Models
{
    public class Committee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Budget { get; set; }

        public ICollection<CommitteehasMembers> CommitteehasMembers { get; set; } = new List<CommitteehasMembers>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
