# Welcome to task!
"task" is a simple tasks/to-do list command line app that aims for simplicity and minimalistic

# Why I make this
Inspired by [this](https://www.reddit.com/r/linux/comments/vbancx/please_i_made_a_cli_tool_that_greets_you_with/) post on the r/linux sub on Reddit. I wanted to create the same thing using .NET Core 6

# Development setup
- Have either [VS Code](https://code.visualstudio.com/) with the C# support installed or [Visual Studio](https://visualstudio.microsoft.com/) with `.Net Desktop Development` workload installed.
- Clone this repository
- Open the cloned repository in VS Code or Visual Studio
- (Skip this if you are using Visual Studio) Run the command ```dotnet restore``` in terminal to install all dependency used in this project
- Run the project

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
```

# Features current on the work
- [x] A command to clear all saved tasks
- [ ] An optional option in the `list` command to show unfinished(undone) tasks
- [ ] On adding, marking task, display the affected task with updated change
- [ ] Have the task list persistent on each command launch
- [ ] Clear the terminal each time `list` is called
- [ ] Export the task list into a file
- [ ] Import a csv task list file to the app
- [ ] A command option in export command to selectively export saved tasks created on a certain date
- [ ] Have a friendlier Usage/Error Message (currently using the default .NET Core Usage/Exception message on some area).
- [ ] Make a release package without having to go through the hassle of preparing development environment

# NuGet Package used in the project
[Spectre Console](https://github.com/spectreconsole/spectre.console)