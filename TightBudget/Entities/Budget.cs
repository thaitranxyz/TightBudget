using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TightBudget.Entities
{
    public class Budget
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public Category Category { get; set; }
        //[Column(TypeName = "decimal(18, 2)")]
        public double Price { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }

    public enum Category
    { 
        Rent,
        Groceries,
        [Display(Name = "Eating Out")]
        EatingOut,
        Transport,
        Subscription,
        Miscellaneous
    }

}
