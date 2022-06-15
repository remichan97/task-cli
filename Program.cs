using Spectre.Console.Cli;

var app = new CommandApp();

app.Configure(it =>
{
	it.AddCommand<AddTasksCommand>("add")
	.WithAlias("a")
	.WithDescription("Add a task to the to-do list")
	.WithExample(new[] { "add", "\"Do homework\"" })
	.WithExample(new[] { "a", "\"Do homework\"" });

	it.AddCommand<MarkTasksCommand>("markdone")
	.WithAlias("md")
	.WithDescription("Mark a task (specified by task number) as done or undone (true/false)")
	.WithExample(new[] { "markdone", "1", "true" })
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
});


app.Run(args);