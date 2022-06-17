using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Controller;

public class DeleteTaskCommand : Command<DeleteTaskCommand.Settings>
{
	public class Settings : CommandSettings
	{
		[CommandArgument(0, "[1]")]
		public int index { get; set; }

		public override ValidationResult Validate()
		{
			return index <= 0 ? ValidationResult.Error("No task found for the given task number. Aborted") : ValidationResult.Success();
		}
	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{
		List<task_cli.Model.Tasks> tasks = TaskController.listAll();
		if (settings.index > tasks.Count)
		{
			AnsiConsole.MarkupLine("[red]Error:[/] No such task for the given task number");
			return 0;
		}
		int pos = settings.index - 1;
		Console.WriteLine("You have selected the following task");
		Console.WriteLine("Task name: " + tasks[pos].TaskName);
		Console.WriteLine("Created on: " + tasks[pos].CreatedOn.ToShortDateString());
		Console.WriteLine("Task status: " + tasks[pos].Status);
		
		if (AnsiConsole.Confirm("[yellow2]Confirmation:[/] Would you like to delete the task?"))
		{
			TaskController.delete(pos);
			AnsiConsole.MarkupLine("[green]Success![/] The Task has been deleted");
		} else {
			Console.WriteLine("Aborted.");
		}

		return 0;
	}
}
