using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using crowdfarming.Data;
using crowdfarming.Models.Domains;

namespace CrowdFarming.Pages_Investments
{
    public class CreateModel : PageModel
    {
        private readonly crowdfarming.Data.FarmerDbContext _context;

        public CreateModel(crowdfarming.Data.FarmerDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InvestorID"] = new SelectList(_context.Investors, "ID", "ID");
        ViewData["ProjectID"] = new SelectList(_context.Projects, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Investment Investment { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Investments.Add(Investment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
