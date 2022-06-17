using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using task_cli.Model;

namespace task_cli.Utils
{
	internal class FileUtils
	{
		private static string fileName = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\tasklist.json";

		/// <summary>
		/// A function to create a file for persist the list store in the program, also can be used to wipe the file per requested
		/// </summary>
		internal static void checkAndCreateDataFile(bool clear)
		{
			// Check whether a file exists, if it does NOT exists, create the file in the current user folder
			// Or if user requested that the file will be cleared, clear everything in the file
			if (File.Exists(fileName) == false || clear == true)
			{
				File.Open(fileName, FileMode.Create).Dispose();
			}
		}

		/// <summary>
		/// A function use for saving the list into the created json file for persistency
		/// </summary>
		/// <param name="tasksList">The list need to be saved</param>
		internal static void WriteJsonFile(List<Tasks> tasksList)
		{
			var json = JsonSerializer.Serialize(tasksList);
			File.WriteAllText(fileName, json);
		}

		/// <summary>
		/// A function to dump the saved json file into the app list
		/// </summary>
		/// <returns>The dumped list from the json file</returns>
		internal static List<Tasks> ReadJsonFile()
		{
			string json = File.ReadAllText(fileName);
			return json == "" ? new List<Tasks>() : JsonSerializer.Deserialize<List<Tasks>>(json);
		}
	}
}
