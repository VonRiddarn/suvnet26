// ----- ----- -----
//		String
// ----- ----- -----

/*
 * Excercise 1
 * 
 * Skriv ett program som frågar användaren om deras namn och skriver ut hur många tecken det innehåller.
*/

Console.Write("Enter your name: ");
Console.WriteLine($"Your name contains {Console.ReadLine()!.Length} letters.");

/*
 * Excercise 2
 * 
 * Läs in en mening och skriv ut den i både versaler och gemener.
*/

string _msg = "I love programming.";
Console.WriteLine($"{_msg.ToLower()}\n{_msg.ToUpper()}");

/*
 * Excercise 3
 * 
 * Låt användaren skriva en text. Kolla om texten innehåller ordet C#, och skriv ut ett meddelande beroende på om det gör det eller inte.
*/

Console.Write("Enter a text: ");
Console.WriteLine(
	Console.ReadLine()!.Contains("c#", StringComparison.OrdinalIgnoreCase) ?
	"Your text contains C# (:" : "Yor text doesn't contain C# ):"
);

/*
 * Excercise 4
 * 
 * Skapa en array med förbjudna ord (t.ex. "dum", "idiot", "korkad"). 
 * Låt användaren skriva en mening och censurera de förbjudna orden genom att ersätta dem med stjärnor (t.ex. "****"). Skriv ut den censurerade meningen.
*/

string[] _forbidden = ["fotboll", "paddel", "golf", "curling", "cricket", "vattenpolo"];

Console.Write("Enter some text, be nice: ");
string _input;

_input = Console.ReadLine()!;

foreach (string bad in _forbidden)
	_input = _input.Replace(bad, "****", StringComparison.OrdinalIgnoreCase);

Console.WriteLine($"Censored text:\n{_input}");