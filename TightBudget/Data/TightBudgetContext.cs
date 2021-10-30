using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TightBudget.Entities;

namespace TightBudget.Data
{
    public class TightBudgetContext : DbContext
    {
        public TightBudgetContext (DbContextOptions<TightBudgetContext> options)
            : base(options)
        {
        }

        public DbSet<TightBudget.Entities.Budget> Budget { get; set; }
    }
}
