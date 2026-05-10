using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project.Data;
using Final_Project.Models;

namespace Final_Project.Pages.Bosses {
    public class IndexModel : PageModel {
        private readonly Final_Project.Data.ArenaDbContext _context;

        public IndexModel(Final_Project.Data.ArenaDbContext context) {
            _context = context;
        }

        public IList<Boss> Boss { get;set; } = default!;

        public async Task OnGetAsync() {
            Boss = await _context.Bosses.ToListAsync();
        }
    }
}
