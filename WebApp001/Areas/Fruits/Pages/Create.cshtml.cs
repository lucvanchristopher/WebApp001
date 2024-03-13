using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp001.Data;
using WebApp001.Models;
using WebApp001.Services;

namespace WebApp001.Areas.Fruits.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext ctx;
        private readonly ImageService imageService;
        public CreateModel(ApplicationDbContext ctx, ImageService imageService)
        {
            this.ctx = ctx;
            this.imageService = imageService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Fruit Fruit { get; set; } = new();

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyFruit = new Fruit();
            if(null != Fruit.Image)
            {
                emptyFruit.Image = await imageService.UploadAsync(Fruit.Image);
            }

            if(await TryUpdateModelAsync(emptyFruit, "fruit", f => f.Name,f=>f.Description,f=>f.Price))
            {
                ctx.Fruit.Add(emptyFruit);
                await ctx.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
