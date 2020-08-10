using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using WeatherTestTask.Weather;

namespace TestTask.Pages.WeatherData
{
    public class DeleteModel : PageModel
    {
        private readonly TestTask.Data.TestTaskContext _context;

        public DeleteModel(TestTask.Data.TestTaskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WeatherDatum WeatherDatum { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WeatherDatum = await _context.WeatherDatum.FirstOrDefaultAsync(m => m.ID == id);

            if (WeatherDatum == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WeatherDatum = await _context.WeatherDatum.FindAsync(id);

            if (WeatherDatum != null)
            {
                _context.WeatherDatum.Remove(WeatherDatum);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
