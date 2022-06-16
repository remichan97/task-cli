using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Controller;

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
		TaskController.add(settings.TaskName);

		AnsiConsole.MarkupLine($"[green]Success![/] The task [turquoise2]{settings.TaskName}[/] has been created");

		return 0;
	}
}
