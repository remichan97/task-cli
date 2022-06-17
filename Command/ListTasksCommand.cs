using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Controller;
using task_cli.Model;

public class ListTasksCommand : Command<ListTasksCommand.Settings>
{
	public class Settings : CommandSettings
	{
		//Empty since the command will not take or consume any arguments/parameters or any additional options
	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{
		List<Tasks> taskList = TaskController.listAll();

		if (taskList.Count == 0)
		{
			AnsiConsole.MarkupLine("[Yellow]No task created![/] Enjoy your day off~");
			return 0;
		}

		Console.Clear();

		var table = new Table();
		table.Centered();
		table.Border(TableBorder.Rounded);
		table.BorderColor(Color.Blue);
		table.AddColumn(new TableColumn("[bold]Task #[/]").Centered());
		table.AddColumn(new TableColumn("[bold]Task Name[/]").Centered());
		table.AddColumn(new TableColumn("[bold]Created on[/]").Centered());
		table.AddColumn(new TableColumn("[bold]Status[/]").Centered());

		for (var i = 0; i < taskList.Count; i++)
		{
			switch (taskList[i].Status)
			{
				case Tasks.TaskStatus.Completed:
					table.AddRow(new string[] {(i + 1).ToString(), taskList[i].TaskName, taskList[i].CreatedOn.ToShortDateString(), $":check_mark_button:"}).Centered();
					break;
				case Tasks.TaskStatus.Undone:
					table.AddRow(new string[] {(i + 1).ToString(), taskList[i].TaskName, taskList[i].CreatedOn.ToShortDateString(), $":cross_mark:"}).Centered();
					break;
			}
		}

		AnsiConsole.Write(table);

		return 0;
	}
}
