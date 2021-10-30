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
    public class DeleteModel : PageModel
    {
        private readonly TightBudget.Data.TightBudgetContext _context;

        public DeleteModel(TightBudget.Data.TightBudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Budget Budget { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Budget = await _context.Budget.FirstOrDefaultAsync(m => m.Id == id);

            if (Budget == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Budget = await _context.Budget.FindAsync(id);

            if (Budget != null)
            {
                _context.Budget.Remove(Budget);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
