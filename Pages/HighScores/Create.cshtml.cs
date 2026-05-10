using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Final_Project.Data;
using Final_Project.Models;

namespace Final_Project.Pages.HighScores
{
    public class CreateModel : PageModel
    {
        private readonly Final_Project.Data.ArenaDbContext _context;

        public CreateModel(Final_Project.Data.ArenaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BossId"] = new SelectList(_context.Bosses, "BossId", "BossId");
        ViewData["PlayerId"] = new SelectList(_context.Players, "PlayerId", "PlayerId");
            return Page();
        }

        [BindProperty]
        public HighScore HighScore { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.HighScores.Add(HighScore);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
