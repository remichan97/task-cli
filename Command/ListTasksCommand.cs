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

		Console.WriteLine("Below is the list of created tasks");

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

					break;
				case Tasks.TaskStatus.Undone:

					break;
			}
			
		}

		AnsiConsole.Write(table);

		return 0;
	}
}
