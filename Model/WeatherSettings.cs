using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_cli.Model
{
    internal class WeatherSettings
    {
        internal enum WeatherUnit {
            Imperial = 1,
            Metric = 2
        }

        public string? CityName { get; set; }
        public WeatherUnit Unit { get; set; }
	}
}