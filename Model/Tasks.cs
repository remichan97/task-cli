namespace task_cli.Model
{
	internal class Tasks
	{
		internal enum TaskStatus
		{
			Completed = 1,
			Undone = 2,
		}

		internal string? TaskName { get; set; }
		internal DateTime CreatedOn { get; set; } = DateTime.Now.ToLocalTime();
		internal DateTime CompletedDate { get; set; }
		internal TaskStatus Status { get; set; } = TaskStatus.Undone;

	}
}