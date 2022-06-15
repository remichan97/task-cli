using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Controller;

public class DeleteTaskCommand : Command<DeleteTaskCommand.Settings>
{
	public class Settings : CommandSettings
	{
		[CommandArgument(0, "[Task Name]")]
		public int index { get; set; }

		public override ValidationResult Validate()
		{
			return index <= 0 ? ValidationResult.Error("No task specified. Aborted") : ValidationResult.Success();
		}
	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{
		TaskController.delete(settings.index);

		AnsiConsole.MarkupLine("[green]Success![/] The Task has been deleted");

		return 0;
	}
}
