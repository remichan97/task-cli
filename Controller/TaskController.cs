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

        internal static void add(Tasks tasks) {
            taskList.Add(tasks);
        }

        internal static void delete(int index) {
            taskList.RemoveAt(index);
        }

        internal static void markDone(int index) {
            taskList.ElementAt(index).CompletedDate = DateTime.Now.ToLocalTime();
            taskList.ElementAt(index).Status = Tasks.TaskStatus.Completed;
        }

        internal static List<Tasks> listAll() {
            return taskList;
        }
    }
}