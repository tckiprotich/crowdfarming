using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crowdfarming.Data;
using crowdfarming.Models.Domains;

namespace CrowdFarming.Pages_Farmer
{
    public class DetailsModel : PageModel
    {
        private readonly crowdfarming.Data.FarmerDbContext _context;

        public DetailsModel(crowdfarming.Data.FarmerDbContext context)
        {
            _context = context;
        }

      public Farmer Farmer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Farmers == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers.FirstOrDefaultAsync(m => m.ID == id);
            if (farmer == null)
            {
                return NotFound();
            }
            else 
            {
                Farmer = farmer;
            }
            return Page();
        }
    }
}
