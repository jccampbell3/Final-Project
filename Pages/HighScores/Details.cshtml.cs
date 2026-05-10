using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project.Data;
using Final_Project.Models;

namespace Final_Project.Pages.HighScores {
    public class DetailsModel : PageModel {
        private readonly Final_Project.Data.ArenaDbContext _context;

        public DetailsModel(Final_Project.Data.ArenaDbContext context) {
            _context = context;
        }

        public HighScore HighScore { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null) {
                return NotFound();
            }

            var highscore = await _context.HighScores.FirstOrDefaultAsync(m => m.HighScoreId == id);

            if (highscore is not null) {
                
                HighScore = highscore;

                return Page();
            }

            return NotFound();
        }
    }
}
