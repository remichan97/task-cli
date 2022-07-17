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
		public string weatherApiKey { get; set; } = "";
		public TemperatureUnit metricUnit { get; set; }

	}
}