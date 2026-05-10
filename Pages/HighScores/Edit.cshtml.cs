using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_Project.Data;
using Final_Project.Models;

namespace Final_Project.Pages.HighScores
{
    public class EditModel : PageModel
    {
        private readonly Final_Project.Data.ArenaDbContext _context;

        public EditModel(Final_Project.Data.ArenaDbContext context)
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

            var highscore =  await _context.HighScores.FirstOrDefaultAsync(m => m.HighScoreId == id);
            if (highscore == null)
            {
                return NotFound();
            }
            HighScore = highscore;
           ViewData["BossId"] = new SelectList(_context.Bosses, "BossId", "BossId");
           ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "PlayerId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(HighScore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HighScoreExists(HighScore.HighScoreId))
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

        private bool HighScoreExists(int id)
        {
            return _context.HighScores.Any(e => e.HighScoreId == id);
        }
    }
}
