using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Controller;

public class DeleteTaskCommand : Command<DeleteTaskCommand.Settings>
{
	public class Settings : CommandSettings
	{
		[CommandArgument(0, "<task_number>")]
		public string? index { get; set; }

		public override ValidationResult Validate()
		{
			try
			{
				int ind = Int32.Parse(index);

				if (ind == 0) return ValidationResult.Error("Task number cannot be zero. Aborted");
			}
			catch (System.Exception)
			{
				return ValidationResult.Error("\nIncorrect syntax. 'delete' requires a task number to delete a task.\n\nYou can use 'list' to list all task or use 'search' to look for a task with its task number.\n\nAborted.");
			}

			return ValidationResult.Success();
		}
	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{
		int index = Int32.Parse(settings.index);
		List<task_cli.Model.Tasks> tasks = TaskController.listAll();

		if (index > tasks.Count)
		{
			AnsiConsole.MarkupLine("[red]Error:[/] No such task for the given task number");
			return 0;
		}
		int pos = index - 1;
		Console.WriteLine("You have selected the following task\n");
		Console.WriteLine("Task name: " + tasks[pos].TaskName);
		Console.WriteLine("\nCreated on: " + tasks[pos].CreatedOn.ToShortDateString());
		Console.WriteLine("\nTask status: " + tasks[pos].Status + "\n");
		
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
