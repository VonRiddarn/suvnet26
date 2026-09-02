using System.Text;

/* 
 *	Things to note (aka pls don't judge me): 
 * 		Obv a JSON db-like object would be better than the CSV structure, 
 * 		but this keeps the project within restrictions / scope.
 * 		Tasks should also use IDs instead of indexes, but this is also a restriction.
 * 
 * 		Due to the restriction of no methods nor classes, this code is NOT DRY.
 * 		That is by design (sadly).
 * 
 *		Technically flag arguments such as -h or --due should be position agnostic.
 *		This was scrapped in favor of redability and less cognitive load.
*/

// TASK CSV STRUCTURE
// 0 : Name, 1: Date, 2: IsDone
// Note: A date of "0001-01-01 00:00:00" will not render. It exists as a dead value.

const string TASKS_PATH = "./tasks.csv";
const string COMMA_PLACEHOLDER = "&cm;";

// ----- ----- -----
// 	 GET ALL TASKS
// ----- ----- -----
if (args.Length == 0)
{
	string[] rows;
	try
	{
		rows = File.ReadAllLines(TASKS_PATH);
	}
	catch (Exception e)
	{
		if (e is FileNotFoundException)
			Console.WriteLine("No tasks to list.");
		else
			Console.WriteLine("Error loading task file.");
		return;
	}

	Console.WriteLine("Showing all tasks...");

	DateTime throwDate = DateTime.MinValue;

	for (int i = 0; i < rows.Length; i++)
	{
		string row = rows[i];
		string[] values = row.Split(',', StringSplitOptions.TrimEntries);

		// Write out the task, or the fact that the task couldn't be parsed.
		// Followed by a line separator.
		if (
		values.Length != 3 ||
		!DateTime.TryParse(values[1], out DateTime date) ||
		!bool.TryParse(values[2], out bool isDone))
			Console.WriteLine($"[ ] {i}\tError parsing csv values.");
		else
			Console.WriteLine($"[{(isDone ? "X" : " ")}] {i}\t{values[0].Replace(COMMA_PLACEHOLDER, ",")}{(date != throwDate ? $"\t DUE: {date.ToShortDateString()}" : string.Empty)}");
	}

	return;
}

// Separate commands and arguments.

string cmd = args[0].ToLower();
string[] localArgs = args.Length < 2 ? [] : args[1..];

// ----- ----- -----
//	   Get help
// ----- ----- -----
if (cmd is "-h")
{
	Console.WriteLine("TODO CLI APPLICAITON");
	Console.WriteLine("To run the appliaction, type \"todo\" followed by a command.");
	Console.WriteLine("Command list:");

	Console.WriteLine("<no args>");
	Console.WriteLine("\tShows all tasks.");

	Console.WriteLine("add <name>");
	Console.WriteLine("\tAdd a task.");
	Console.WriteLine("\tFlags:");
	Console.WriteLine("\t\t--due:\tSets a due date for the task.");

	Console.WriteLine("remove <id>");
	Console.WriteLine("\tRemove one or more tasks.");

	Console.WriteLine("toggle <id>");
	Console.WriteLine("\tToggle a tasks checked state.");
}

// ----- ----- -----
// 	  Add a task
// ----- ----- -----
else if (cmd is "add")
{
	DateTime dueDate = new();


	if (localArgs.Length is not 3 and not 1)
	{
		Console.WriteLine("Invalid argument count. No action taken.");
		Environment.Exit(-1);
	}

	if (localArgs.Length == 3)
	{
		if (localArgs[1].ToLower() is "--due")
		{
			if (!DateTime.TryParse(localArgs[2], out dueDate))
			{
				Console.WriteLine($"Could not parse date from string \"{localArgs[2]}\".");
				Environment.Exit(-1);
			}
		}
		else
		{
			Console.WriteLine("Invalid argument signature. Add a due date using the format \"--due <date>\".");
			Environment.Exit(-1);
		}
	}

	(string name, DateTime due, bool isDone) = (localArgs[0].Replace(",", COMMA_PLACEHOLDER), dueDate, false);
	string[] rows = [];

	try
	{
		rows = [.. File.ReadAllLines(TASKS_PATH)];
	}
	catch (Exception e)
	{
		if (e is not FileNotFoundException)
			Console.WriteLine($"Error loading task file. Exception: {e.Message}");
	}

	rows = [.. rows, $"{name},{due},{isDone}"];

	try
	{
		File.WriteAllLines(TASKS_PATH, rows);
		Console.WriteLine($"\"{name.Replace(COMMA_PLACEHOLDER, ",")}\" has been added to the task list with due date: {due}.");
	}
	catch
	{
		Console.WriteLine($"Failed to write to task file.");
		Environment.Exit(-1);
	}
}

// ----- ----- -----
// 	 Remove a task
// ----- ----- -----
else if (cmd is "remove")
{
	// Early return for when there are no arguments.
	if (localArgs.Length != 1)
	{
		Console.WriteLine($"\"{cmd}\" must be passed with at exactly 1 argument!");
		Environment.Exit(1);
	}

	string[] rows = [];
	try
	{
		rows = File.ReadAllLines(TASKS_PATH);
	}
	catch (Exception e)
	{
		if (e is FileNotFoundException)
		{
			Console.WriteLine("Task file does not exist. Please create at least one task.");
			Environment.Exit(0);
		}
		else
		{
			Console.WriteLine($"Error loading tasks from file. Exception {e.Message}");
			Environment.Exit(0);
		}
	}

	string arg = localArgs[0];

	// Not a valid index
	if (!int.TryParse(arg, out int intArg))
	{
		Console.WriteLine($"Failed to parse \"{arg}\" to int.");
		Environment.Exit(-1);
	}

	// Out of range
	if (intArg < 0 || intArg > rows.Length - 1)
	{
		Console.WriteLine($"\"{intArg}\" is out of range.");
		Environment.Exit(-1);
	}

	string taskName = rows[intArg].Split(',')[0].Replace(COMMA_PLACEHOLDER, ",");

	// Shift all items to the left before cutting the end of the array.
	for (int i = intArg; i < rows.Length - 1; i++)
		rows[i] = rows[i + 1];

	Array.Resize(ref rows, rows.Length - 1);

	File.WriteAllLines(TASKS_PATH, rows);
	Console.WriteLine($"Removed task \"{taskName}\" at index {intArg}.");
}

// ----- ----- -----
// 	 Toggle a task
// ----- ----- -----
else if (cmd is "toggle")
{
	// Early return for when there are no arguments.
	if (localArgs.Length != 1)
	{
		Console.WriteLine($"\"{cmd}\" must be passed with at exactly 1 argument!");
		Environment.Exit(1);
	}

	string[] rows = [];
	try
	{
		rows = File.ReadAllLines(TASKS_PATH);
	}
	catch (Exception e)
	{
		if (e is FileNotFoundException)
		{
			Console.WriteLine("Task file does not exist. Please create at least one task.");
			Environment.Exit(0);
		}
		else
		{
			Console.WriteLine($"Error loading tasks from file. Exception {e.Message}");
			Environment.Exit(0);
		}
	}

	string arg = localArgs[0];

	// Not a valid index
	if (!int.TryParse(arg, out int intArg))
	{
		Console.WriteLine($"Failed to parse \"{arg}\" to int.");
		Environment.Exit(-1);
	}

	// Out of range
	if (intArg < 0 || intArg > rows.Length - 1)
	{
		Console.WriteLine($"\"{intArg}\" is out of range.");
		Environment.Exit(-1);
	}

	// Get the values of the task.
	string[] values = rows[intArg].Split(',', StringSplitOptions.TrimEntries);

	// Parse the CVS length and the boolean value
	if (values.Length != 3)
	{
		Console.WriteLine($"Invalid CSV structure for task at index: {intArg}.");
		Environment.Exit(-1);
	}

	if (!bool.TryParse(values[2], out bool isDone))
	{
		Console.WriteLine($"Can't parse check value for task at index: {intArg}.");
		Environment.Exit(-1);
	}

	rows[intArg] = string.Join(',', [values[0], values[1], !isDone]);

	File.WriteAllLines(TASKS_PATH, rows);
	Console.WriteLine($"\"{values[0]}\" set to {(isDone ? "todo" : "done")}.");
}