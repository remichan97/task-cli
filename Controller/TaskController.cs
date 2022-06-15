using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task_cli.Model;

namespace task_cli.Controller
{
	internal class TaskController
	{
		internal static List<Tasks> taskList = new List<Tasks>();

		internal static void add(string taskName)
		{
			Tasks tsk = new Tasks();
			tsk.TaskName = taskName;
			taskList.Add(tsk);
		}

		internal static void delete(int index)
		{
			taskList.RemoveAt(index);
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
		}

		internal static List<Tasks> listAll()
		{
			return taskList;
		}
	}
}