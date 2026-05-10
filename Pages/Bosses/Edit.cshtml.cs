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

namespace Final_Project.Pages.Bosses
{
    public class EditModel : PageModel
    {
        private readonly Final_Project.Data.ArenaDbContext _context;

        public EditModel(Final_Project.Data.ArenaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Boss Boss { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boss =  await _context.Bosses.FirstOrDefaultAsync(m => m.BossId == id);
            if (boss == null)
            {
                return NotFound();
            }
            Boss = boss;
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

            _context.Attach(Boss).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BossExists(Boss.BossId))
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

        private bool BossExists(int id)
        {
            return _context.Bosses.Any(e => e.BossId == id);
        }
    }
}
