using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_cli.Model
{
	internal class WeatherConfig
	{
		internal enum TemperatureUnit
		{
			Imperial = 1,
			Metric = 2
		}
		public string? CityName { get; set; }
		public TemperatureUnit metricUnit { get; set; }

	}
}