using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WeatherTestTask.Weather;

namespace TestTask.Pages.WeatherData
{
    public class CreateModel2 : PageModel
    {
        private readonly TestTask.Data.TestTaskContext _context;
        public CreateModel2(TestTask.Data.TestTaskContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public IFormFile[] Uploads { get; set; }
        string[] validFileTypes = { ".xls", ".xlsx", ".csv" };

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            foreach(IFormFile Upload in Uploads)
            {
                if (Upload != null)
                {
                    bool fileReadCorrectly = true;
                    XSSFWorkbook xssfwb;
                    xssfwb = new XSSFWorkbook();
                    try
                    {
                        using (var outputStream = Upload.OpenReadStream())
                        {
                            xssfwb = new XSSFWorkbook(outputStream);
                        }
                    }
                    catch { fileReadCorrectly = false; }
                    if (fileReadCorrectly)
                    {
                        for (int i = 0; i < xssfwb.NumberOfSheets; i++)
                            if (xssfwb.GetSheetAt(i).LastRowNum > 4)
                                for (int j = 4; j < xssfwb.GetSheetAt(i).LastRowNum; j++)
                                {
                                    DateTime date, time;
                                    if (DateTime.TryParse(xssfwb.GetSheetAt(i).GetRow(j).GetCell(0).ToString(), out date) && DateTime.TryParse(xssfwb.GetSheetAt(i).GetRow(j).GetCell(1).ToString(), out time))
                                    {
                                        decimal temperatureC, airWetness, td;
                                        int pressure, _windSpeed, _cloudness, _h, _vv;
                                        string _veatherEffects = "", windDirection = "";
                                        decimal.TryParse(xssfwb.GetSheetAt(i).GetRow(j).GetCell(2).ToString(), out temperatureC);
                                        decimal.TryParse(xssfwb.GetSheetAt(i).GetRow(j).GetCell(3).ToString(), out airWetness);
                                        decimal.TryParse(xssfwb.GetSheetAt(i).GetRow(j).GetCell(4).ToString(), out td);

                                        int.TryParse(xssfwb.GetSheetAt(i).GetRow(j).GetCell(5).ToString(), out pressure);
                                        int.TryParse(xssfwb.GetSheetAt(i).GetRow(j).GetCell(7).ToString(), out _windSpeed);
                                        int.TryParse(xssfwb.GetSheetAt(i).GetRow(j).GetCell(8).ToString(), out _cloudness);
                                        int.TryParse(xssfwb.GetSheetAt(i).GetRow(j).GetCell(9).ToString(), out _h);
                                        int.TryParse(xssfwb.GetSheetAt(i).GetRow(j).GetCell(10).ToString(), out _vv);
                                        if (xssfwb.GetSheetAt(i).GetRow(j).LastCellNum == 12)
                                            windDirection = xssfwb.GetSheetAt(i).GetRow(j).GetCell(6, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();

                                        if (xssfwb.GetSheetAt(i).GetRow(j).LastCellNum == 12)
                                            _veatherEffects = xssfwb.GetSheetAt(i).GetRow(j).GetCell(11, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();

                                        _context.WeatherDatum.Add(new WeatherDatum
                                        {
                                            Date = date,
                                            Time = time,
                                            TemperatureC = temperatureC,
                                            AirWetness = airWetness,
                                            Td = td,
                                            Pressure = pressure,
                                            WindDirection = windDirection,
                                            windSpeed = _windSpeed,
                                            cloudness = _cloudness,
                                            h = _h,
                                            vv = _vv,
                                            veatherEffects = _veatherEffects
                                        });

                                    }
                                }
                        await _context.SaveChangesAsync();
                    }
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
