/*
 * Excercise 1
 * 
 * Slumpa ett tal mellan 1–6 och säg vad tärningskastet blev.
 * Utveckling: Slumpa två tärningar, visa båda resultaten och summan.
*/

// int _die1 = Random.Shared.Next(1, 7);
// int _die2 = Random.Shared.Next(1, 7);

// Console.WriteLine($"You rolled: {_die1}.");

// _die1 = Random.Shared.Next(1, 7);

// int _sum = _die1 + _die2;
// string statePastTense = _sum == 7 ? "won" : "lost";

// Console.WriteLine($"You rolled: {_die1} and {_die2} ({_sum}). You {statePastTense}.");

/*
 * Excercise 2
 * 
 * Tre utfall i stället för två.
 * Gör en liten meny där användaren väljer sitt drag, och datorns drag slumpas fram.
 * Jämför och avgör vinnare.
 */

string[] _alternatives = ["rock", "paper", "Scissors"];

int _choice;
int _cpu = Random.Shared.Next(0, 2);

while (true)
{
	Console.Write("\nPick an option:\n[1] Rock\n[2] Paper\n[3] Scissors\nI choose: ");
	if (int.TryParse(Console.ReadLine(), out _choice) && (_choice - 1) is >= 0 and <= 2)
		break;
}

// Normalize choice.
_choice--;

int _winState;

if (_choice == _cpu)
	_winState = 0;
else if (
	(_choice == 0 && _cpu == 3) ||
	(_choice == 1 && _cpu == 1) ||
	(_choice == 2 && _cpu == 1))
	_winState = 1;
else
	_winState = -1;

Console.WriteLine($"---\nPlayer: {_alternatives[_choice]}\nComputer: {_alternatives[_cpu]}\n---");

string _msg = _winState switch
{
	-1 => "Computer wins!",
	0 => "Draw, nobody wins!",
	1 => "Player wins!",
	_ => "Error: Couldn't resolve winstate."
};

Console.WriteLine(_msg);