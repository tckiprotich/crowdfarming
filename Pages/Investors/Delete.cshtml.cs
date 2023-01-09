using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crowdfarming.Data;
using crowdfarming.Models.Domains;

namespace CrowdFarming.Pages_Investors
{
    public class DeleteModel : PageModel
    {
        private readonly crowdfarming.Data.FarmerDbContext _context;

        public DeleteModel(crowdfarming.Data.FarmerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Investor Investor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Investors == null)
            {
                return NotFound();
            }

            var investor = await _context.Investors.FirstOrDefaultAsync(m => m.ID == id);

            if (investor == null)
            {
                return NotFound();
            }
            else 
            {
                Investor = investor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Investors == null)
            {
                return NotFound();
            }
            var investor = await _context.Investors.FindAsync(id);

            if (investor != null)
            {
                Investor = investor;
                _context.Investors.Remove(Investor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
