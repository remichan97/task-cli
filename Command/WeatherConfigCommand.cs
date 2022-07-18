using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Controller;

public class WeatherConfigCommand : Command<WeatherConfigCommand.Settings>
{
	public class Settings : CommandSettings
	{
		[CommandArgument(0, "<city_name>")]
		public string? CityName { get; set; }
		[CommandArgument(1, "metric/imperial")]
		public string? TempUnit { get; set; }

		public override ValidationResult Validate()
		{
			return !(TempUnit!.ToLower().Equals("metric")) || !(TempUnit.ToLower().Equals("imperial")) ? ValidationResult.Error("Invalid value! Temperature unit must be either metric or imperial") : ValidationResult.Success();
		}
	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{
		string city = settings.CityName!;

		string tempUnit = settings.TempUnit!;

		WeatherController.writeWeatherConfig(city, tempUnit);

		AnsiConsole.MarkupLine("[green]Success![/] The weather display configuration has been saved!");
		return 0;
	}
}
