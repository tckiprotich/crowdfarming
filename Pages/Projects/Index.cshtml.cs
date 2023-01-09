using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crowdfarming.Data;
using crowdfarming.Models.Domains;

namespace CrowdFarming.Pages_Projects
{
    public class IndexModel : PageModel
    {
        private readonly crowdfarming.Data.FarmerDbContext _context;

        public IndexModel(crowdfarming.Data.FarmerDbContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Projects != null)
            {
                Project = await _context.Projects
                .Include(p => p.Farmer).ToListAsync();
            }
        }
    }
}
