using System;
using System.Collections.Generic;
using System.Dynamic;
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
    public class IndexModel : PageModel
    {
        private readonly TestTask.Data.TestTaskContext _context;

        public IndexModel(TestTask.Data.TestTaskContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string Year { get; set; }
        public SelectList Years { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Mounth { get; set; }
        public SelectList Mounths { get; set; }
        public IList<WeatherDatum> WeatherDatum { get;set; }
        public async Task OnGetAsync()
        {
            IQueryable<int> yearsQuery = from wd in _context.WeatherDatum
                                            orderby wd.Date.Year
                                            select wd.Date.Year;

            var weatherData = from wd in _context.WeatherDatum
                         select wd;
            if (!string.IsNullOrEmpty(Year))
            {
                weatherData = weatherData.Where(x => x.Date.Year == int.Parse(Year));
                IQueryable<int> mounthsQuery = from wd in weatherData
                                               orderby wd.Date.Month
                                               select wd.Date.Date.Month;
                Mounths = new SelectList(await mounthsQuery.Distinct().ToListAsync());
                if (!string.IsNullOrEmpty(Mounth) && Mounths.Any())
                    weatherData = weatherData.Where(x => x.Date.Month == int.Parse(Mounth));
            }
                
            Years = new SelectList(await yearsQuery.Distinct().ToListAsync());
            
            
            //var weatherDataSelected = weatherData.Where(x => x.Date.Year == int.Parse(Year.OptionLabel));
            WeatherDatum = await weatherData.ToListAsync();
            //WeatherDatum = await _context.WeatherDatum.ToListAsync();
        }
    }
}
