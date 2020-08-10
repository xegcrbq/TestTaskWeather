using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherTestTask.Weather;

namespace TestTask.Data
{
    public class TestTaskContext : DbContext
    {
        public TestTaskContext (DbContextOptions<TestTaskContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherTestTask.Weather.WeatherDatum> WeatherDatum { get; set; }
    }
}
