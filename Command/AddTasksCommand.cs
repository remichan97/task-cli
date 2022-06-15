using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

public class AddTasksCommand : Command<AddTasksCommand.Settings>
{
	public class Settings : CommandSettings
	{
		[CommandArgument(0, "[Task Name]")]
		public string? TaskName { get; set; }

		public override ValidationResult Validate()
		{
			return TaskName is null ? ValidationResult.Error("No task name specified. Aborted.") : ValidationResult.Success();
		}
	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{


		AnsiConsole.MarkupLine($"[green]Success![/] The task has been created");

		return 0;
	}
}
