using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Controller;

public class ClearAllTasksCommand : Command<ClearAllTasksCommand.Settings>
{
	public class Settings : CommandSettings
	{

	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{
		if (AnsiConsole.Confirm($"[yellow]Confirmation:[/] All saved tasks will be deleted. Would you like to clear the task list?"))
		{
			AnsiConsole.MarkupLine($"[green]Success![/] All saved tasks has been deleted.");
		}
		else
		{
			Console.WriteLine("Aborted");
		}
		return 0;
	}
}
