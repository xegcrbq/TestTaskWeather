using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestTask.Data;
using WeatherTestTask.Weather;

namespace TestTask.Pages.WeatherData
{
    public class CreateModel : PageModel
    {
        private readonly TestTask.Data.TestTaskContext _context;

        public CreateModel(TestTask.Data.TestTaskContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WeatherDatum WeatherDatum { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WeatherDatum.Add(WeatherDatum);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
