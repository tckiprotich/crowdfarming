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

namespace CrowdFarming.Pages_Farmer
{
    public class EditModel : PageModel
    {
        private readonly crowdfarming.Data.FarmerDbContext _context;

        public EditModel(crowdfarming.Data.FarmerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Farmer Farmer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Farmers == null)
            {
                return NotFound();
            }

            var farmer =  await _context.Farmers.FirstOrDefaultAsync(m => m.ID == id);
            if (farmer == null)
            {
                return NotFound();
            }
            Farmer = farmer;
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

            _context.Attach(Farmer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerExists(Farmer.ID))
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

        private bool FarmerExists(int id)
        {
          return _context.Farmers.Any(e => e.ID == id);
        }
    }
}
