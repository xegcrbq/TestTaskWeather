using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherTestTask.Weather
{
    public class WeatherDatum
    {
        public int ID { get; set; }
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Время (московское)")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [Display(Name = "T °C")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TemperatureC { get; set; }
        [Display(Name = "Отн. влажность воздуха, %")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? AirWetness { get; set; }
        [Display(Name = "Td")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Td { get; set; }
        [Display(Name = "Атм. давление, мм рт.ст.")]
        public int? Pressure { get; set; }
        [Display(Name = "Направление ветра")]
        public string WindDirection { get; set; }
        [Display(Name = "Скорость ветра, м/с")]
        public int? windSpeed { get; set; }
        [Display(Name = "Облачность, %")]
        public int? cloudness { get; set; }
        [Display(Name = "h")]
        public int? h { get; set; }
        [Display(Name = "VV")]
        public int? vv { get; set; }
        [Display(Name = "Погодные явления")]
        public string veatherEffects { get; set; }
    }
}
