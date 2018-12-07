using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuDatabase.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public float AmountSpent { get; set; }
        public float AmountAdded { get; set; }

        public Committee Committee { get; set; }
    }
}
