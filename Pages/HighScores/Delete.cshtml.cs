using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project.Data;
using Final_Project.Models;

namespace Final_Project.Pages.HighScores
{
    public class DeleteModel : PageModel
    {
        private readonly Final_Project.Data.ArenaDbContext _context;

        public DeleteModel(Final_Project.Data.ArenaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HighScore HighScore { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscore = await _context.HighScores.FirstOrDefaultAsync(m => m.HighScoreId == id);

            if (highscore is not null)
            {
                HighScore = highscore;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscore = await _context.HighScores.FindAsync(id);
            if (highscore != null)
            {
                HighScore = highscore;
                _context.HighScores.Remove(HighScore);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
