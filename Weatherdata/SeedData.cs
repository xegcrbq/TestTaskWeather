using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Data;
using System;
using System.Linq;
using WeatherTestTask.Weather;

namespace TestTask.WeatherData
{
    public static class SeedData
    {
        private static readonly string[] wDir = new[]
        {
            "Штиль", "С", "Ю", "З", "В", "СЗ", "СВ", "ЮЗ", "ЮВ", "З, ЮЗ"
        };
        private static readonly string[] weatherCond = new[]
        {
            "Дымка", "Туман", "Снег", "Слабый снег", "Дождь", "Слабый дождь"
        };
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TestTaskContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TestTaskContext>>()))
            {
                // Look for any movies.
                if (context.WeatherDatum.Any())
                {
                    return;   // DB has been seeded
                }
                var rng = new Random();
                for(int i = 0; i  < 5; i++)
                    context.WeatherDatum.AddRange(
                        new WeatherDatum
                        {
                            Date = DateTime.Parse(String.Format("{0}.{1}.{2}", rng.Next(1, 30), rng.Next(1, 12), rng.Next(2010, 2013))),
                            Time = DateTime.Parse(String.Format("{0}:{1}", rng.Next(0, 23), rng.Next(0, 59))),
                            TemperatureC = rng.Next(-40, 40),
                            AirWetness = rng.Next(0, 100),
                            Td = rng.Next(0, 200),
                            Pressure = rng.Next(700, 800),
                            WindDirection = wDir[rng.Next(wDir.Length)],
                            windSpeed = rng.Next(20),
                            h = rng.Next(450, 3000),
                            vv = rng.Next(200),
                            veatherEffects = weatherCond[rng.Next(weatherCond.Length)]
                        }
                    );
                context.SaveChanges();
            }
        }
    }
}