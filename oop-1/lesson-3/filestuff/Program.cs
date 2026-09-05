// ----- ----- -----
//		Files
// ----- ----- -----

/* 
 * Excercise 1
 * 
 * Läs in en textfil och räkna hur många rader den innehåller.
 * Visa resultatet i konsolen.
*/

try
{
	Console.WriteLine($"\"rows.txt\" has {File.ReadAllLines("rows.txt").Length} lines.");
}
catch
{
	Console.WriteLine($"\"rows.txt\" cannot be read. Does the file exist?");
}

/*
 * Excercise 2
 * 
 * Läs in en textfil och låt användaren skriva in ett ord.
 * Räkna hur många gånger ordet förekommer i filen och visa resultatet.
 * Utveckling: Visa även vilka rader ordet förekommer på.
 * Utveckling 2: Gör sökningen okänslig för versaler/gemener (case insensitive).
 * Utveckling 3: Visa raderna där ordet förekommer, med ordet markerat (t.ex. med asterisker *ord*).
*/

// const string FIND_WORD = "find-word.txt";
// try
// {
// 	string[] rows = File.ReadAllLines(FIND_WORD);

// 	Console.Write("What word would you like to find? ");
// 	string searchTerm = Console.ReadLine()!;

// 	int lastIndex = 0;
// 	(int row, string content)[] instances = new (int, string)[rows.Length]; // No List<> ):

// 	for (int i = 0; i < rows.Length; i++)
// 	{
// 		var c = rows[i];

// 		if (c.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase))
// 			instances[lastIndex++] = (i, c);
// 	}

// 	Array.Resize(ref instances, lastIndex);

// 	Console.Clear();
// 	Console.WriteLine($"Your word appears {instances.Length} times in \"{FIND_WORD}\".");

// 	foreach (var (row, content) in instances)
// 	{
// 		Console.Write($"{row + 1}|\t");
// 		int currentIndex = 0;

// 		// Lowkey fugly printer 
// 		// Print until the index of the search term, then stop, print the term, and jump the index to after the term.
// 		// Continue until depleated.
// 		while (true)
// 		{
// 			int matchIndex = content.IndexOf(searchTerm, currentIndex, StringComparison.OrdinalIgnoreCase);

// 			if (matchIndex == -1)
// 			{
// 				Console.Write(content[currentIndex..]);
// 				break;
// 			}

// 			Console.Write(content[currentIndex..matchIndex]);

// 			Console.ForegroundColor = ConsoleColor.Green;
// 			Console.Write(content[matchIndex..(matchIndex + searchTerm.Length)]);
// 			Console.ResetColor();

// 			currentIndex = matchIndex + searchTerm.Length;
// 		}

// 		Console.WriteLine();
// 	}
// }
// catch
// {
// 	Console.WriteLine($"\"find-word.txt\" cannot be read. Does the file exist?");
// }

/*
 * Exercise 3
 * 
 * Läs in en textfil och skapa en ny fil som innehåller de första 5 raderna från den ursprungliga filen.
 * Spara den nya filen med samma namn som den ursprungliga med tillägget "_summary".
*/

const string SUM_FILE_NAME = "to-summarize";
const int DESIRED_ROWS = 5;
string[] _summary = new string[DESIRED_ROWS];
int _rows = 0;

try
{
	foreach (string line in File.ReadLines($"{SUM_FILE_NAME}.txt"))
	{
		if (_rows >= DESIRED_ROWS)
			break;

		_summary[_rows++] = line;
	}
}
catch (Exception e)
{
	Console.WriteLine($"Couldn't read \"{SUM_FILE_NAME}.txt\". Exception: {e.Message}");
	Environment.Exit(-1);
}

try
{
	File.WriteAllLines($"{SUM_FILE_NAME}_summary.txt", _summary);
	Console.WriteLine($"File summarized to {DESIRED_ROWS} rows in {SUM_FILE_NAME}_summary.txt.");
}
catch
{
	Console.WriteLine($"Couldn't write file \"{SUM_FILE_NAME}_summary.txt\".");
	Environment.Exit(-1);
}