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

public class IndexModel : PageModel {
    private readonly ArenaDbContext _context;

    public IndexModel(ArenaDbContext context) {
        _context = context;
    }

    public List<Player> Player { get; set; } = new();
    public string CurrentSort { get; set; } = string.Empty;
    public string CurrentFilter { get; set; } = string.Empty;
    public string NameSort { get; set; } = string.Empty;
    public string StrengthSort { get; set; } = string.Empty;

    [BindProperty(SupportsGet = true)]
    public int CurrentPage { get; set; } = 1;

    public int TotalPages { get; set; }
    public const int PageSize = 10;

    public async Task OnGetAsync(string sortOrder, string searchString) {
        CurrentSort = sortOrder;
        CurrentFilter = searchString;

        NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        StrengthSort = sortOrder == "Strength" ? "strength_desc" : "Strength";

        IQueryable<Player> playersIQ = from p in _context.Players select p;

        if (!String.IsNullOrEmpty(searchString)) {
            playersIQ = playersIQ.Where(p =>
                p.Username.ToLower().Contains(searchString.ToLower()) ||
                p.Title.ToLower().Contains(searchString.ToLower()));
        }

        switch (sortOrder) {
            case "name_desc": playersIQ = playersIQ.OrderByDescending(p => p.Username); break;
            case "Strength": playersIQ = playersIQ.OrderBy(p => p.StrengthLevel); break;
            case "strength_desc": playersIQ = playersIQ.OrderByDescending(p => p.StrengthLevel); break;
            default: playersIQ = playersIQ.OrderBy(p => p.Username); break;
        }

      
        int totalRecords = await playersIQ.CountAsync();
        TotalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);
        CurrentPage = Math.Max(1, Math.Min(CurrentPage, TotalPages == 0 ? 1 : TotalPages));

        Player = await playersIQ
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .AsNoTracking()
            .ToListAsync();
    }
}