using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuDatabase.Models
{
    public class DeltaUpsilonContext : DbContext
    {
        public DbSet<Dues> Dues { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<CommitteehasMembers> CommitteeMembers { get; set; }
        public DeltaUpsilonContext(DbContextOptions<DeltaUpsilonContext> options)
        : base(options)
        {
            // create but leave empty to call the base class constructor
        }
    }
}
