using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

public class MarkTasksCommand : Command<MarkTasksCommand.Settings>
{
	public class Settings : CommandSettings
	{
		[CommandArgument(0, "[Task Name]")]
		public int index { get; set; }
		[CommandArgument(1, "[true/false]")]
		public bool Done {get;set;}

		public override ValidationResult Validate()
		{
			return index <= 0 ? ValidationResult.Error("No task selected. Aborted") : ValidationResult.Success();
		}
	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{
		

		AnsiConsole.MarkupLine($"");

		return 0;
	}
}
