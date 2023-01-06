using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using crowdfarming.Models.Domains;
using crowdfarming.Data;

namespace crowdfarming.Pages.api
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly FarmerDbContext farmerDbContext;

        public List<Project> projects { get; set; }
        public List<Farmer> farmers { get; set; }
        public List<Investment> investments { get; set; }
        public List<Investment> investments2 { get; set; }

        public Index(FarmerDbContext FarmerDbContext)
        {
            projects = FarmerDbContext.Projects.ToList();
            farmers = FarmerDbContext.Farmers.ToList();
            investments = FarmerDbContext.Investments.ToList();
            investments2 = FarmerDbContext.Investments.ToList();
            farmerDbContext = FarmerDbContext;
        }

    
       


        public void OnGet()
        {
        }
    }
}