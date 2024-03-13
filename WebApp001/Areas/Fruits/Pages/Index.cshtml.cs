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
    public class IndexModel : PageModel
    {
        private readonly WebApp001.Data.ApplicationDbContext _context;

        public IndexModel(WebApp001.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Fruit> Fruit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Fruit = await _context.Fruit.ToListAsync();
        }
    }
}
