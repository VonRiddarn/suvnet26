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
 * Tänk dig ett program där användaren matar in ett ord. Ordet visas på skärmen och användaren får mata in ytterligare ett ord. 
 * Båda orden visas på skärmen osv. Detta fortsätter tills användaren matar in "sluta".
 * 
 * CREATE variable for WORDS (def: empty string)
 * CREATE cached variable INPUT
 * LOOP (INF)
 * 		INPUT = USER IN
 * 		IF "q"
 * 			BREAK
 * 		ELSE
 * 			WORDS += INPUT
 * 			PRINT WORDS
*/

// string _words = string.Empty;
// string? _input;

// while (true)
// {
// 	Console.Write("Enter a word (or \"q\" to exit): ");
// 	_input = Console.ReadLine();

// 	// Early return
// 	if (_input is "q" or "Q")
// 		break;

// 	_words += $"{_input} ";
// 	Console.WriteLine(_words);
// }

/*
 * Excercise 3
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

// int _sum = 0;

// while (true)
// {
// 	Console.Write("Enter a number (or \"sum\" to sumarize): ");
// 	string? input = Console.ReadLine();
// 	if (string.Equals(input, "sum", StringComparison.OrdinalIgnoreCase))
// 		break;
// 	else if (string.IsNullOrWhiteSpace(input))
// 		Console.WriteLine("You must proivde an input!");
// 	else if (int.TryParse(input, out int n))
// 		_sum += n;
// 	else
// 		Console.WriteLine("Not a valid number!");
// }

// Console.WriteLine($"The sum of your numbers is: {_sum}.");

/*
 * Excercise 4
 * 
 * Tänk dig ett progam som ser ut så här när det körs: 

	Ange en X-koordinat (1-5): 4
	Ange en Y-koordinat (1-5): 3

	y
	5 *
	4 *
	3 *       X
	2 *
	1 *
	0 * * * * * *
	  0 1 2 3 4 5 x
 
 * CREATE INT X
 * CREATE INT Y
 * LOOP(INF)
 * 	GET USER IN
 * 		IF is int
 * 			IF IN RANGE (> 0 < 5)
 * 				X = USER IN (INT)
 * 				BREAK
 * 			ELSE
 * 				PRINT: "Number must be between 1 and 5."
 * 		ELSE
 * 			PRINT: "Must enter a number."
 * [REPEAT FOR Y]
 * 
 * (Switching to my regular pseudo coding as this format makes my problem solving slower)
 * 
 * Print "y"
 * new line
 * Loop rows backwards (maxR--)
 * 	Loop columns forwards (maxC). start -1 (for graphics)
 * 		if col == -1: row
 * 		if col == 0 || row == 0: *
 * 		if col == X && row == Y: X
 * 		else: " "
 * new line
 * " "
 * loop through maxC forward, start at 0
 * if col != maxC: col
 * else: col + " x"
*/

// Board size (keep as single digit to not ruing graphics)
const int X_SIZE = 7;
const int Y_SIZE = 7;

// Cache
int _x, _y;

// Force correct input X
while (true)
{
	Console.WriteLine($"Enter X coord (1 - {X_SIZE}): ");
	if (int.TryParse(Console.ReadLine(), out _x))
		if (_x > 0 && _x <= X_SIZE)
			break;
		else
			Console.WriteLine($"Coord must be between 1 - {X_SIZE}!");
	else
		Console.WriteLine("Must enter an integer.");
}

// Force correct input Y
while (true)
{
	Console.WriteLine($"Enter Y coord (1 - {Y_SIZE}): ");
	if (int.TryParse(Console.ReadLine(), out _y))
		if (_y > 0 && _y <= Y_SIZE)
			break;
		else
			Console.WriteLine($"Coord must be between 1 - {Y_SIZE}!");
	else
		Console.WriteLine("Must enter an integer.");
}

// Draw graphics
Console.Clear();
Console.WriteLine("y");
for (int r = Y_SIZE; r >= 0; r--)
{
	for (int c = -1; c <= X_SIZE; c++)
	{
		if (c is -1)
			Console.Write(r);
		else if (c is 0 || r is 0)
			Console.Write(" * ");
		else if (c == _x && r == _y)
			Console.Write(" X ");
		else
			Console.Write("   ");
	}
	Console.WriteLine();
}

for (int i = 0; i <= X_SIZE; i++)
	Console.Write(i != X_SIZE ? $"  {i}" : $"  {i} x");

/*
 * Shorten challange (AKA TENARY HELL!!!!!)
 * Inspired by teachers solution to see if I could replicate the result.
 * Whackified by also adding the y-graphic into the tenary.
*/
// Draw graphics
// Console.Clear();
// for (int r = Y_SIZE + 1; r >= 0; r--, Console.WriteLine())
// 	for (int c = -1; c <= X_SIZE; c++)
// 		Console.Write(r > Y_SIZE && c is -1 ? "y" : c is -1 ? r : c is 0 && r <= Y_SIZE || r is 0 ? " * " : c == _x && r == _y ? " X " : "   ");
// for (int i = 0; i <= X_SIZE; i++)
// 	Console.Write(i != X_SIZE ? $"  {i}" : $"  {i} x");