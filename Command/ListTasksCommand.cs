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

		Console.Clear();

		if (taskList.Count == 0)
		{
			AnsiConsole.MarkupLine("[Yellow]No task created![/] Enjoy your day off~");
			return 0;
		}

		var table = new Table();
		table.Centered();
		table.Border(TableBorder.Rounded);
		table.AddColumn("Task #");
		table.AddColumn("Task Name");
		table.AddColumn("Created on");
		table.AddColumn("Status");

		for (var i = 0; i < taskList.Count; i++)
		{
			switch (taskList[i].Status)
			{
				case Tasks.TaskStatus.Completed:
					table.AddRow(new string[] {(i + 1).ToString(), taskList[i].TaskName, taskList[i].CreatedOn.ToShortDateString(), $":check_mark_button:"});
					break;
				case Tasks.TaskStatus.Undone:
					table.AddRow(new string[] {(i + 1).ToString(), taskList[i].TaskName, taskList[i].CreatedOn.ToShortDateString(), $":cross_mark:"});
					break;
			}
			
		}

		AnsiConsole.Write(table);

		return 0;
	}
}
