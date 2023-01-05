using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using crowdfarming.Data;
using crowdfarming.Models.Domains;

namespace CrowdFarming.Pages_Farmer
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
            return Page();
        }

        [BindProperty]
        public Farmer Farmer { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Farmers.Add(Farmer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
