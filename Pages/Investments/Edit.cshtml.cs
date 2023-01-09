using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crowdfarming.Data;
using crowdfarming.Models.Domains;

namespace CrowdFarming.Pages_Investments
{
    public class EditModel : PageModel
    {
        private readonly crowdfarming.Data.FarmerDbContext _context;

        public EditModel(crowdfarming.Data.FarmerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Investment Investment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Investments == null)
            {
                return NotFound();
            }

            var investment =  await _context.Investments.FirstOrDefaultAsync(m => m.ID == id);
            if (investment == null)
            {
                return NotFound();
            }
            Investment = investment;
           ViewData["InvestorID"] = new SelectList(_context.Investors, "ID", "ID");
           ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Investment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestmentExists(Investment.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InvestmentExists(int id)
        {
          return _context.Investments.Any(e => e.ID == id);
        }
    }
}
