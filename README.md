# Welcome to task-cli!
"task-cli" is a simple tasks/to-do list command line app that aims for simplicity and minimalistic for those who loves using terminal at a daily basis

# Why I make this
Inspired by [this](https://www.reddit.com/r/linux/comments/vbancx/please_i_made_a_cli_tool_that_greets_you_with/) post on the r/linux sub on Reddit. I wanted to create the same thing using .NET Core 6. This project also act as a self-learning material for myself

# Installation
Please make sure that you have the [.NET 6 Runtime](https://dotnet.microsoft.com/en-us/download) installed on your machine before running the app.

The provided package are ready to use when downloaded. Just [download](https://github.com/remichan97/task-cli/releases) the release, extract it to somewhere, and call the terminal on the extracted folder, and the app is ready to use!

# Usage
```bash
# Create a task
task add "task_name"
task a "task_name"

# Mark a task as done
task markdone "task_number" true
task md "task_number" true

# Mark a task as undone
task markdone "task_number" false
task md "task_number" false

# Delete a task
task delete "task_number"
task del "task_number"

# List undone tasks
task list -u
task ls -u

# Search a task
task search "keyword"
```

# Development setup
- Have either [VS Code](https://code.visualstudio.com/) with the C# support installed or [Visual Studio](https://visualstudio.microsoft.com/) with `.Net Desktop Development` workload installed.
- [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download) if using VS Code
- Clone this repository
- Open the cloned repository in VS Code or Visual Studio
- (Skip this if you are using Visual Studio) Run the command ```dotnet restore``` in terminal to install all dependency used in this project
- Run the project

# Features currently in the work
- [x] A command to clear all saved tasks
- [x] Have the task list persistent on each command launch
- [x] A command to search a task by keyword
- [x] On marking task, display the affected task with updated change
- [x] Clear the terminal each time `list` is called
- [x] An optional option in the `list` command to show unfinished(undone) tasks
- [x] Have a friendlier Error Message in possible places (currently using the default Exception message on some area).
- [x] Add a current date and time display when `list` is invoked.
- [ ] Add a simple configuration command for weather displaying when `list` is invoked
- [ ] Add a current weather display when `list` is invoked.

# NuGet Package used in the project
[Spectre Console](https://github.com/spectreconsole/spectre.console)