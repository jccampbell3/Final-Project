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

namespace Final_Project.Pages;

public class IndexModel : PageModel {
    private readonly ArenaDbContext _context;

    public IndexModel(ArenaDbContext context) {
        _context = context;
    }

    public List<HighScore> TopScores { get; set; } = new();
    public List<Boss> Bosses { get; set; } = new();

    public async Task OnGetAsync() {
        TopScores = await _context.HighScores
            .Include(h => h.Player)
            .Include(h => h.Boss)
            .OrderByDescending(h => h.KillCount)
            .Take(6)
            .ToListAsync();

        Bosses = await _context.Bosses
            .OrderBy(b => b.Name)
            .ToListAsync();
    }
}