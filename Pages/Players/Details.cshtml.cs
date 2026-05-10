using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Pages.Players;

public class DetailsModel : PageModel {
    private readonly ArenaDbContext _context;

    public DetailsModel(ArenaDbContext context) {
        _context = context;
    }

    public Player Player { get; set; } = null!;
    public List<HighScore> HighScores { get; set; } = new();


    public async Task<IActionResult> OnGetAsync(int? id) {
    if (id == null) return NotFound();

    Player = await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == id);
    if (Player == null) return NotFound();

    HighScores = await _context.HighScores
        .Include(h => h.Boss)
        .Where(h => h.PlayerId == id)
        .OrderByDescending(h => h.KillCount)
        .ToListAsync();

    return Page();
}




    public async Task<IActionResult> OnPostDeleteAsync(int id, int scoreId) {
        var score = await _context.HighScores.FindAsync(scoreId);
        if (score != null) {
            _context.HighScores.Remove(score);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage(new { id });
    }
}