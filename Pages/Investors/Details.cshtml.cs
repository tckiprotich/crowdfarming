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
    public class DetailsModel : PageModel
    {
        private readonly crowdfarming.Data.FarmerDbContext _context;

        public DetailsModel(crowdfarming.Data.FarmerDbContext context)
        {
            _context = context;
        }

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
    }
}
