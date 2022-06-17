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

		public override ValidationResult Validate()
		{
			return keyword is null ? ValidationResult.Error("No keyword specified. Aborted") : ValidationResult.Success();
		}
	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{

		List<Tasks> taskList = TaskController.listAll().FindAll(it => it.TaskName.Contains(settings.keyword));

		if (taskList.Count == 0)
		{
			AnsiConsole.MarkupLine($"No tasks found for the term [turquoise2]{settings.keyword}[/]");
			return 0;
		}

		AnsiConsole.MarkupLine($"[green3_1]{taskList.Count}[/] task(s) found for the term [turquoise2]{settings.keyword}[/]");


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
