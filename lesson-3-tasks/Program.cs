// ----- ----- -----
// 	  Pseudocode
// ----- ----- -----

/*
 * Exercise 1
 * 
 * Tänk dig ett program som ber användaren mata in två tal, adderar dem och skriver ut resultatet.
 * 
 * Get input A
 * Parse to int
 * IF FAIL:
 * 		PRINT FAIL
 * 		RETRY
 * Get input B
 * Parse to int
 * IF FAIL:
 * 		PRINT FAIL
 * 		RETRY
 * Print (A + B)
*/

// int _a;
// int _b;

// while (true)
// {
// 	Console.Write("Enter input A: ");
// 	if (int.TryParse(Console.ReadLine(), out _a))
// 		break;
// 	else
// 		Console.WriteLine("Failed. Input must be an integer.");
// }

// while (true)
// {
// 	Console.Write("Enter input B: ");
// 	if (int.TryParse(Console.ReadLine(), out _b))
// 		break;
// 	else
// 		Console.WriteLine("Failed. Input must be an integer.");
// }

// Console.WriteLine($"Sum: {_a + _b}");

/*
 * Excercise 2
 * 
 * Skriv programmet för denna pseudokod
		SKAPA en variabel som heter SUMMA och sätt den till 0
		LOOPA oändligt
			SKAPA en tom sträng som heter INPUT
			LÄS in en rad från användaren och spara i INPUT
			OM INPUT är lika med "sluta" (case insensitive)
				AVBRYT loopen
			ANNARS OM INPUT är tom
				SKRIV UT "Du måste mata in något!"
			ANNARS OM INPUT går att tolka som ett heltal
				ADDERA heltalet till SUMMA
			ANNARS
				SKRIV UT "Det där var inte ett giltigt tal!"
		SKRIV UT "Summan av talen är: " + SUMMA
*/

int sum = 0;

while (true)
{
	Console.Write("Enter a number (or \"sum\" to sumarize): ");
	string? input = Console.ReadLine();
	if (string.Equals(input, "sum", StringComparison.OrdinalIgnoreCase))
		break;
	else if (string.IsNullOrWhiteSpace(input))
		Console.WriteLine("You must proivde an input!");
	else if (int.TryParse(input, out int n))
		sum += n;
	else
		Console.WriteLine("Not a valid number!");
}

Console.WriteLine($"The sum of your numbers is: {sum}.");