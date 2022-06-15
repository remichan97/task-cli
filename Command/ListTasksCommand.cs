using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Controller;
using task_cli.Model;

public class ListTasksCommand : Command<ListTasksCommand.Settings>
{
	public class Settings : CommandSettings
	{

	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{
		List<Tasks> taskList = TaskController.listAll();

		if (taskList.Count == 0)
		{
			AnsiConsole.MarkupLine("[Yellow]No task created![/] Enjoy your day off~");
			return 0;
		}

		var table = new Table();
		table.Border(TableBorder.Rounded);
		table.AddColumn("Task #");
		table.AddColumn("Task Name");
		table.AddColumn("Created on");
		table.AddColumn("Status");

		

		AnsiConsole.Write(table);

		return 0;
	}
}
