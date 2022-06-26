using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Controller;
using task_cli.Model;

public class ListTasksCommand : Command<ListTasksCommand.Settings>
{
	public class Settings : CommandSettings
	{
		[CommandOption("-u|--undone")]
		public bool undone { get; set; }
	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{
		List<Tasks> taskList = TaskController.listAll();

		int v = taskList.FindAll(it => it.Status == Tasks.TaskStatus.Undone).Count();

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
		table.AddColumn(new TableColumn("[bold]Task Name[/]"));
		table.AddColumn(new TableColumn("[bold]Created on[/]"));
		table.AddColumn(new TableColumn("[bold]Status[/]").Centered());

		if (settings.undone)
		{
			if (v == 0)
			{
				Console.WriteLine("You have no undone tasks");
				return 0;
			}

			Console.WriteLine("Displaying undone tasks only");

			taskList.ForEach(it =>
			{
				if (it.Status == Tasks.TaskStatus.Undone) table.AddRow(new string[] { (taskList.FindIndex(x => x.TaskName == it.TaskName) + 1).ToString(), it.TaskName!, it.CreatedOn.ToShortDateString(), $":cross_mark:" });

			});

			AnsiConsole.Write(table);

			return 0;

		}

		for (var i = 0; i < taskList.Count; i++)
		{
			switch (taskList[i].Status)
			{
				case Tasks.TaskStatus.Completed:
					table.AddRow(new string[] { (i + 1).ToString(), taskList[i].TaskName!, taskList[i].CreatedOn.ToShortDateString(), $":check_mark_button:" });
					break;
				case Tasks.TaskStatus.Undone:
					table.AddRow(new string[] { (i + 1).ToString(), taskList[i].TaskName!, taskList[i].CreatedOn.ToShortDateString(), $":cross_mark:" });
					break;
			}
		}

		AnsiConsole.Write(table);

		return 0;
	}
}
