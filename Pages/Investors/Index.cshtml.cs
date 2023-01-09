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
    public class IndexModel : PageModel
    {
        private readonly crowdfarming.Data.FarmerDbContext _context;

        public IndexModel(crowdfarming.Data.FarmerDbContext context)
        {
            _context = context;
        }

        public IList<Investor> Investor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Investors != null)
            {
                Investor = await _context.Investors.ToListAsync();
            }
        }
    }
}
