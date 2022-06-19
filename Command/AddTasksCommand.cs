using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Controller;

public class AddTasksCommand : Command<AddTasksCommand.Settings>
{
	public class Settings : CommandSettings
	{
		[CommandArgument(0, "<task_name>")]
		public string? TaskName { get; set; }
	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{
		TaskController.add(settings.TaskName!);

		AnsiConsole.MarkupLine($"[green]Success![/] The task [turquoise2]{settings.TaskName}[/] has been created");

		return 0;
	}
}
