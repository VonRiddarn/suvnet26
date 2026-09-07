/*
 * Excercise 1
 * 
 * Skriv kod som läser in denna textfil. 
 * Filen innehåller en lista med namn, men alla rader är inte ifyllda. 
 * Skriv ut alla namn från filen, men hoppa över tomma rader.
 */

// using System.Text;

// static string PrintNames(string filePath)
// {
// 	StringBuilder sb = new();
// 	try
// 	{
// 		foreach (string row in File.ReadAllLines(filePath))
// 			if (!string.IsNullOrWhiteSpace(row))
// 				sb.AppendLine(row);
// 	}
// 	catch
// 	{
// 		Console.WriteLine($"Error reading file at: \"{filePath}\"");
// 	}

// 	return sb.ToString();
// }

/*
 * Excercise 2
 * 
 * Skriv ett program som visar denna meny: 
	1. Visa dagens datum och tid
	2. Lista alla namn
	3. Avsluta

	Val: 
 * Användaren ska kunna skriva in 1, 2 eller 3. Detta ska hända i de olika fallen:

    Dagens datum och tid skrivs ut.1 Sätt texten till blå text.
    Programmet utför samma sak som i övning 1.
    Programmet avslutas.

 * Om användaren skriver in något annat ska programmet skriva ut "Felaktigt val" och visa menyn igen. 
 * Efter varje val skall menyn visas igen, tills användaren väljer att avsluta. 
*/

// ConsoleColor _color = ConsoleColor.White;
// string _msg = string.Empty;

// while (true)
// {
// 	Console.Clear();
// 	Console.ForegroundColor = _color;
// 	Console.Write($"{_msg}");
// 	_msg = string.Empty;

// 	Console.ResetColor();

// 	Console.WriteLine("\n1: Show today's date.\n2: List all names.\n3: Exit.");

// 	Console.Write("\nChoice: ");

// 	switch (Console.ReadKey().Key)
// 	{
// 		case ConsoleKey.D1:
// 			DateTime dt = DateTime.Now;
// 			_color = ConsoleColor.Blue;
// 			_msg = $"{dt:D} {dt:T}";
// 			break;
// 		case ConsoleKey.D2:
// 			_msg = PrintNames("names.txt");
// 			break;
// 		case ConsoleKey.D3:
// 			Environment.Exit(0);
// 			break;
// 		default:
// 			_msg = "Invalid choice.";
// 			_color = ConsoleColor.Red;
// 			break;
// 	}
// }

/*
 * Excercise 3
 * 
 * Vi fortsätter med refaktorering och metoder! Hur skulle du kunna förbättra denna kod med hjälp av metoder? Den har nämligen några problem:
    Inga metoder: Allt sker sekventiellt. Detta gör det svårt att utöka programmet eller återanvända delar av koden.
    Kodrepetition: flera Console.ForegroundColor = ConsoleColor.Red; och Console.WriteLine för felmeddelanden.
    Nästlade kodblock i flera nivåer: if-satser i flera nivåer gör att det blir svårt att läsa.
 */

class Program
{

	const string USERNAME = "admin";
	const string PASSWORD = "1234";

	static void WriteLineColor(string msg, ConsoleColor color) => WriteColor($"{msg}\n", color);
	static void WriteColor(string msg, ConsoleColor color)
	{
		Console.ForegroundColor = color;
		Console.Write(msg);
		Console.ResetColor();
	}

	// Returning a tuple, because we're not allowed structs yet
	static (string username, string password) LoginFormLoop()
	{
		string username;
		string password;

		// USERNAME
		while (true)
		{
			Console.Write("Enter your username:");
			username = Console.ReadLine()!;

			if (!string.IsNullOrWhiteSpace(username))
				break;

			WriteLineColor("Username may not be empty.", ConsoleColor.Red);
		}

		// PASSWORD
		while (true)
		{
			Console.Write("Enter your password:");
			password = Console.ReadLine()!;

			if (!string.IsNullOrWhiteSpace(password))
				break;

			WriteLineColor("Password may not be empty.", ConsoleColor.Red);
		}

		return (username, password);
	}

	static bool ValidateUser(string username, string password)
		=> username == USERNAME && password == PASSWORD;

	// ----- ----- -----
	// 	 PROGRAM ROOT
	// ----- ----- -----
	static void Main()
	{
		var (username, password) = LoginFormLoop();

		if (ValidateUser(username, password))
			WriteLineColor("Login successfull!", ConsoleColor.Green);
		else
		{
			// This is OWASP compliant! 🤓☝️ 
			// https://cheatsheetseries.owasp.org/cheatsheets/Authentication_Cheat_Sheet.html#authentication-responses
			WriteLineColor("Wrong username or password!", ConsoleColor.Red);
		}
	}
}