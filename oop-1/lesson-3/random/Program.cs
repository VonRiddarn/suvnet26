/*
 * Excercise 1
 * 
 * Slumpa ett tal mellan 1–6 och säg vad tärningskastet blev.
 * Utveckling: Slumpa två tärningar, visa båda resultaten och summan.
*/

int _die1 = Random.Shared.Next(1, 7);
int _die2 = Random.Shared.Next(1, 7);

Console.WriteLine($"You rolled: {_die1}.");

_die1 = Random.Shared.Next(1, 7);

int _sum = _die1 + _die2;
string statePastTense = _sum == 7 ? "won" : "lost";

Console.WriteLine($"You rolled: {_die1} and {_die2} ({_sum}). You {statePastTense}.");