using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TightBudget.Data;
using TightBudget.Entities;

namespace TightBudget.Pages.Budgets
{
    public class IndexModel : PageModel
    {
        private readonly TightBudget.Data.TightBudgetContext _context;

        public IndexModel(TightBudget.Data.TightBudgetContext context)
        {
            _context = context;
        }

        public IList<Budget> Budget { get; set; }
        [BindProperty]
        public Budget BudgetInput { get; set; }

        public async Task OnGetAsync(string searchString, string sortOrder)
        {
            Budget = await _context.Budget.ToListAsync();
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) || sortOrder == "Name" ? "name_desc" : "Name";
            ViewData["DateSortParam"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.ToLower().TrimStart().TrimEnd();
                Budget = Budget.Where(x => x.Item.ToLower().Replace(" ", "").Contains(searchString) || x.Description.Replace(" ", "").Contains(searchString)).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    Budget = Budget.OrderByDescending(b => b.Item).ToList();
                    break;
                case "Name":
                    Budget = Budget.OrderBy(b => b.Item).ToList();
                    break;
                case "date_desc":
                    Budget = Budget.OrderByDescending(b => b.Item).ToList();
                    break;
                default: 
                    Budget = Budget.OrderBy(b => b.Date).ToList();
                    break;
            }           

            var price = from b in Budget select b.Price;
            var budget = 1076;
            ViewData["TotalPrice"] = price.Sum();
            ViewData["MoneyLeft"] = budget - price.Sum();
            ViewData["Budget"] = budget;
            ViewData["CurrentDate"] = DateTime.Now;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("./Index");
            }

            _context.Budget.Add(BudgetInput);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

    
}
