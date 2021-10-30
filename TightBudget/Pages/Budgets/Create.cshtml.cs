﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TightBudget.Data;
using TightBudget.Entities;

namespace TightBudget.Pages.Budgets
{
    public class CreateModel : PageModel
    {
        private readonly TightBudget.Data.TightBudgetContext _context;

        public CreateModel(TightBudget.Data.TightBudgetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Budget Budget { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Budget.Add(Budget);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
