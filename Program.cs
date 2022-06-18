using Spectre.Console;
using Spectre.Console.Cli;
using task_cli.Utils;

FileUtils.checkAndCreateDataFile(false);

var app = new CommandApp();

app.Configure(it =>
{
	it.SetApplicationName("task");

	it.AddCommand<AddTasksCommand>("add")
	.WithAlias("a")
	.WithDescription("Add a task to the to-do list")
	.WithExample(new[] { "add", "\"Do homework\"" });

	it.AddCommand<MarkTasksCommand>("markdone")
	.WithAlias("md")
	.WithDescription("Mark a task (specified by task number) as done or undone (true/false)")
	.WithExample(new[] { "md", "1", "false" });

	it.AddCommand<DeleteTaskCommand>("delete")
	.WithAlias("del")
	.WithDescription("Delete a task (specified by task number)")
	.WithExample(new[] { "delete", "1" })
	.WithExample(new[] { "del", "1", });

	it.AddCommand<ListTasksCommand>("list")
	.WithAlias("l")
	.WithDescription("List all saved tasks");

	it.AddCommand<ClearAllTasksCommand>("clear")
	.WithDescription("Delete all saved tasks");

	it.AddCommand<SearchTasksCommand>("search")
	.WithAlias("s")
	.WithDescription("Search for tasks in the saved task list");

});

app.Run(args);
