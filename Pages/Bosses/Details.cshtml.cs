using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Pages.Bosses;

public class DetailsModel : PageModel {
    private readonly ArenaDbContext _context;

    public DetailsModel(ArenaDbContext context) {
        _context = context;
    }

    public Boss Boss { get; set; } = null!;
    public List<HighScore> TopPlayers { get; set; } = new();


    public async Task<IActionResult> OnGetAsync(int? id) {
        if (id == null) return NotFound();

        Boss = await _context.Bosses.FirstOrDefaultAsync(b => b.BossId == id);
        if (Boss == null) return NotFound();

        TopPlayers = await _context.HighScores
            .Include(h => h.Player)
            .Where(h => h.BossId == id)
            .OrderByDescending(h => h.KillCount)
            .Take(25)
            .ToListAsync();

        return Page();
    }


    public async Task<IActionResult> OnPostDeleteAsync(int id, int scoreId) {
        var score = await _context.HighScores.FindAsync(scoreId);
        if (score != null)
        {
            _context.HighScores.Remove(score);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage(new { id });
    }
}