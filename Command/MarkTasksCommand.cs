using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Controller;

public class MarkTasksCommand : Command<MarkTasksCommand.Settings>
{
	public class Settings : CommandSettings
	{
		[CommandArgument(0, "[Task Name]")]
		public int index { get; set; }
		[CommandArgument(1, "[true/false]")]
		public bool Done {get;set;}

		public override ValidationResult Validate()
		{
			return index <= 0 ? ValidationResult.Error("No task specified. Aborted") : ValidationResult.Success();
		}
	}

	public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
	{
		List<task_cli.Model.Tasks> taskList = TaskController.listAll();

		TaskController.markTasks(settings.index, settings.Done);

		switch (settings.Done)
		{
			case true:
				AnsiConsole.MarkupLine($"[green]Success![[/]] The task [turquoise2]{taskList[settings.index].TaskName}[/] has been marked as [lime]done[/]");
				break;
			case false:
				AnsiConsole.MarkupLine($"[green]Success![[/]] The task [turquoise2]{taskList[settings.index].TaskName}[/] has been marked as [orange1]undone[/]");
				break;
		}

		return 0;
	}
}
