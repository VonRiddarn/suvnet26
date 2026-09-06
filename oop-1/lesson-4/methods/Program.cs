/*
 * Excercise 1
 * 
 * Skriv en enkel metod som skriver ut "Hello, World!" i konsolen. 
 * Anropa sedan metoden tre gånger på raken från din kod. 
 * Koden kan heta vad som helst, men tex kan den heta PrintHello.
*/

// static void PrintMessage(string msg, int count)
// {
// 	for (int i = 0; i < count; i++)
// 		Console.WriteLine(msg);
// }

// PrintMessage("Hello world!", 3);

/*
 * Excercise 2
 * 
 * Tar en sträng som parameter, den kan heta name.
 * Skriver ut en sträng i stil med $"Hej {name}, hur mår du idag?" i konsolen.
*/

// static void GreetPerson(string name) =>
// 	Console.WriteLine($"Hello {name}, I hope you have a fantastic day!");

// Console.Write("Enter name: ");
// GreetPerson(Console.ReadLine()!);

/*
 * Excercise 3
 * 
 * Tar en decimal som parameter, den kan heta amount.
 * Returnerar en decimal som är 30% av amount.
 * Skriv ett litet program som ber användaren skriva in sin inkomst, anropar CalculateTax med inkomsten och skriver ut siffran som metoder skickar tillbaka.
*/

// static decimal CalculateTax(decimal amount) => amount * 0.3m;

// decimal _income;
// while (true)
// {
// 	Console.Write("Enter your income: ");
// 	if (decimal.TryParse(Console.ReadLine(), out _income))
// 		break;
// }

// Console.WriteLine($"Tax deducted: {CalculateTax(_income)} (Left: {_income - CalculateTax(_income)})");

/*
 * Excercise 4
 * 
 * Tar en sträng som parameter (den ska användas som meddelande).
 * Skriver ut meddelandet i konsolen med vit text på röd bakgrund.
 * Nollställer färgerna i konsolen efteråt.
 * Gör sedan ett program som först skriver ut "Detta är ett vanligt meddelande", 
 * sedan anropar WriteWarning med meddelandet "Detta är ett varningsmeddelande" 
 * och slutligen skriver ut "Detta är ett annat vanligt meddelande".
*/

// static void WriteWarning(string msg)
// {
// 	Console.ForegroundColor = ConsoleColor.White;
// 	Console.BackgroundColor = ConsoleColor.Red;
// 	Console.Write(msg);

// 	Console.ResetColor();
// 	Console.WriteLine();
// }


// Console.WriteLine("Normal message.");
// WriteWarning("Oh no, an error has occured!");
// Console.WriteLine("Another normal message.");

/*
 * Excercise 5
 * 
 * Tar en sträng som parameter (den ska användas som prompt när användaren ska mata in ett tal).
 * Returnerar ett heltal som användaren matat in.
 * (Svårare) Om användaren matar in något som inte är ett heltal, 
 * ska metoden skriva ut ett felmeddelande och fråga igen tills användaren matar in ett giltigt heltal.
*/

static T ReadLine<T>(string msg) where T : IParsable<T>
{
	while (true)
	{
		Console.Write(msg);
		if (T.TryParse(Console.ReadLine()!, null, out T? result))
			if (result is not null)
				return result;
	}
}

int _age = ReadLine<int>("Enter your age: ");
float _percent = ReadLine<float>("How sure are you? ");

Console.WriteLine($"You are: {_age} years old (you're {_percent}% sure at least).");