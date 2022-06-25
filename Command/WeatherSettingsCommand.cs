using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Controller;
using task_cli.Model;

public class WeatherSettingsCommand : Command<WeatherSettingsCommand.Settings>
{
	public class Settings : CommandSettings
	{

	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{

		AnsiConsole.Ask<string>("[blue]Question:[/] Which city you would like to show weather for? ");

		AnsiConsole.Prompt(new MultiSelectionPrompt<String>()
			.Title("Would you like the temperature to be displayed in:")
			.AddChoices(new String[] {"Metric?", "Imperial?"})
		);

		return 0;
	}
}
