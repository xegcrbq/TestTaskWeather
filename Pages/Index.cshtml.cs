using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WeatherTestTask.Weather;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTask.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TestTask.Data.TestTaskContext  _context;

        public IndexModel(TestTask.Data.TestTaskContext context)
        {
            _context = context;
        }
        public IList<WeatherDatum> WeatherDatum { get; set; }
        public async Task OnGetAsync()
        {
            WeatherDatum = await _context.WeatherDatum.ToListAsync();
        }
    }
}
