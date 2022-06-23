using task_cli.Model;
using task_cli.Utils;

namespace task_cli.Controller
{
	internal class TaskController
	{
		private static List<Tasks> taskList = FileUtils.ReadJsonFile();

		internal static void add(string taskName)
		{
			Tasks tsk = new Tasks();
			tsk.TaskName = taskName;
			taskList.Add(tsk);

			FileUtils.WriteJsonFile(taskList);
		}

		internal static void delete(int index)
		{
			taskList.RemoveAt(index);
			FileUtils.WriteJsonFile(taskList);
		}

		internal static void markTasks(int index, bool done)
		{
			switch (done)
			{
				case true:
					taskList.ElementAt(index).Status = Tasks.TaskStatus.Completed;
					break;
				case false:
					taskList.ElementAt(index).Status = Tasks.TaskStatus.Undone;
					break;
			}
			FileUtils.WriteJsonFile(taskList);
		}

		internal static List<Tasks> listAll()
		{
			return taskList;
		}
	}
}