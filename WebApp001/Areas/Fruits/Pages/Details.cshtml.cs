using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp001.Data;
using WebApp001.Models;

namespace WebApp001.Areas.Fruits.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WebApp001.Data.ApplicationDbContext _context;

        public DetailsModel(WebApp001.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Fruit Fruit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fruit = await _context.Fruit.FirstOrDefaultAsync(m => m.Id == id);
            if (fruit == null)
            {
                return NotFound();
            }
            else
            {
                Fruit = fruit;
            }
            return Page();
        }
    }
}
