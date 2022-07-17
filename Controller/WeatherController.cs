using task_cli.Model;
using task_cli.Utils;

namespace task_cli.Controller
{
	internal class WeatherController
	{
		internal static WeatherConfig getWeatherConfig()
		{
			return FileUtils.getWeatherConfig();
		}

		internal static void writeWeatherConfig(string city, string metric)
		{
			WeatherConfig config = new WeatherConfig();

			config.CityName = city;

			switch (metric)
			{
				case "metric":
					config.metricUnit = WeatherConfig.TemperatureUnit.Metric;
					break;
				case "imperial":
					config.metricUnit = WeatherConfig.TemperatureUnit.Imperial;
					break;
			}

			FileUtils.writeWeatherConfig(config);
		}

		internal static void getWeatherData()
		{
			
		}
	}
}