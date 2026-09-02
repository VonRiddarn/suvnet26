// ----- ----- -----
// 	  Pseudocode
// ----- ----- -----

/*
 * Exercise 1
 * 
 * "Tänk dig ett program som ber användaren mata in två tal, adderar dem och skriver ut resultatet"
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

int _a;
int _b;

while (true)
{
	Console.Write("Enter input A: ");
	if (int.TryParse(Console.ReadLine(), out _a))
		break;
	else
		Console.WriteLine("Failed. Input must be an integer.");
}

while (true)
{
	Console.Write("Enter input B: ");
	if (int.TryParse(Console.ReadLine(), out _b))
		break;
	else
		Console.WriteLine("Failed. Input must be an integer.");
}

Console.WriteLine($"Sum: {_a + _b}");