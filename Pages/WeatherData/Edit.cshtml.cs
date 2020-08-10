using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using WeatherTestTask.Weather;

namespace TestTask.Pages.WeatherData
{
    public class EditModel : PageModel
    {
        private readonly TestTask.Data.TestTaskContext _context;

        public EditModel(TestTask.Data.TestTaskContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WeatherDatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherDatumExists(WeatherDatum.ID))
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

        private bool WeatherDatumExists(int id)
        {
            return _context.WeatherDatum.Any(e => e.ID == id);
        }
    }
}
