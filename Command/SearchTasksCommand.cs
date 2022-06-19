using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Controller;
using task_cli.Model;

public class SearchTasksCommand : Command<SearchTasksCommand.Settings>
{
	public class Settings : CommandSettings
	{
		[CommandArgument(0, "<keyword>")]
		public string? keyword { get; set; }
	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{

		List<Tasks> taskList = TaskController.listAll();

		var table = new Table();
		table.Centered();
		table.Border(TableBorder.Rounded);
		table.BorderColor(Color.Blue);
		table.AddColumn(new TableColumn("[bold]Task #[/]").Centered());
		table.AddColumn(new TableColumn("[bold]Task Name[/]").Centered());
		table.AddColumn(new TableColumn("[bold]Created on[/]").Centered());
		table.AddColumn(new TableColumn("[bold]Status[/]").Centered());

		int count = 0;

		taskList.ForEach(it =>
		{
			if (it.TaskName!.Contains(settings.keyword!))
			{
				count++;
				switch (it.Status)
				{
					case Tasks.TaskStatus.Completed:
						table.AddRow(new string[] { (taskList.FindIndex(x => x.TaskName == it.TaskName) + 1).ToString(), it.TaskName!, it.CreatedOn.ToShortDateString(), $":check_mark_button:" }).Centered();
						break;
					case Tasks.TaskStatus.Undone:
						table.AddRow(new string[] { (taskList.FindIndex(x => x.TaskName == it.TaskName) + 1).ToString(), it.TaskName!, it.CreatedOn.ToShortDateString(), $":cross_mark:" }).Centered();
						break;
				}
			}
		});
		AnsiConsole.MarkupLine($"[green3_1]{count}[/] task(s) found for the term [turquoise2]{settings.keyword}[/]");

		if (count > 0) AnsiConsole.Write(table);

		return 0;
	}
}
