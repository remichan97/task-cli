namespace task_cli.Model
{
	internal class Tasks
	{
		internal enum TaskStatus
		{
			Completed = 1,
			Undone = 2,
		}
		public string? TaskName { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.Now.ToLocalTime();
		public TaskStatus Status { get; set; } = TaskStatus.Undone;
	}
}