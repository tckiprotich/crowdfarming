using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crowdfarming.Data;
using crowdfarming.Models.Domains;

namespace CrowdFarming.Pages_Investments
{
    public class DeleteModel : PageModel
    {
        private readonly crowdfarming.Data.FarmerDbContext _context;

        public DeleteModel(crowdfarming.Data.FarmerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Investment Investment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Investments == null)
            {
                return NotFound();
            }

            var investment = await _context.Investments.FirstOrDefaultAsync(m => m.ID == id);

            if (investment == null)
            {
                return NotFound();
            }
            else 
            {
                Investment = investment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Investments == null)
            {
                return NotFound();
            }
            var investment = await _context.Investments.FindAsync(id);

            if (investment != null)
            {
                Investment = investment;
                _context.Investments.Remove(Investment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
