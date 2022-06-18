using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Controller;
using task_cli.Model;

public class MarkTasksCommand : Command<MarkTasksCommand.Settings>
{
	public class Settings : CommandSettings
	{
		[CommandArgument(0, "<task_number>")]
		public string? index { get; set; }
		[CommandArgument(1, "<true/false>")]
		public bool Done { get; set; }

		public override ValidationResult Validate()
		{
			try
			{
				int ind = Int32.Parse(index);

				if (ind == 0)
				{
					return ValidationResult.Error("Task number cannot be zero. Aborted");
				}
			}
			catch (System.Exception)
			{
				return ValidationResult.Error("Incorrect syntax. 'markdone' requires a task number to delete a task.\n\nYou can use 'list' to list all tasks or use 'search' to look for a task with its task number.\n\nAborted.");
			}

			return ValidationResult.Success();
		}
	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{
		int index = Int32.Parse(settings.index);

		List<task_cli.Model.Tasks> taskList = TaskController.listAll();

		int pops = index - 1;

		TaskController.markTasks(pops, settings.Done);

		switch (settings.Done)
		{
			case true:
				AnsiConsole.MarkupLine($"[green]Success![/] The task [turquoise2]{taskList[pops].TaskName}[/] has been marked as [lime]done[/]");
				break;
			case false:
				AnsiConsole.MarkupLine($"[green]Success![/] The task [turquoise2]{taskList[pops].TaskName}[/] has been marked as [orange1]undone[/]");
				break;
		}

		var table = new Table();
		table.Centered();
		table.Border(TableBorder.Rounded);
		table.BorderColor(Color.Blue);
		table.AddColumn(new TableColumn("[bold]Task #[/]").Centered());
		table.AddColumn(new TableColumn("[bold]Task Name[/]"));
		table.AddColumn(new TableColumn("[bold]Created on[/]"));
		table.AddColumn(new TableColumn("[bold]Status[/]").Centered());

		switch (taskList[pops].Status)
		{
			case Tasks.TaskStatus.Completed:
				table.AddRow(new string[] { settings.index.ToString(), taskList[pops].TaskName, taskList[pops].CreatedOn.ToShortDateString(), $":check_mark_button:" });
				break;
			case Tasks.TaskStatus.Undone:
				table.AddRow(new string[] { settings.index.ToString(), taskList[pops].TaskName, taskList[pops].CreatedOn.ToShortDateString(), $":cross_mark:" });
				break;
		}

		AnsiConsole.Write(table);

		return 0;
	}
}
