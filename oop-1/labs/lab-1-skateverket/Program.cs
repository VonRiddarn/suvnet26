using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

partial class Program
{
	static void Main()
	{
		(string label, Action action)[] choices = [
			("Beräkna skatt för en person.", CalculateTaxSingle),
			("Beräkna skatt för flera personer från fil.", CalculateTaxMultiple),
			("Avsluta", Exit)
		];

		while (true)
		{
			Console.Clear();
			ShowMenuUI("Skatteverket", [.. choices.Select(v => v.label)]);

			if (ReadChoice(choices.Length, out int choiceIndex))
				choices[choiceIndex].action();
		}
	}

	// ----- ----- -----
	//	   HELPERS
	// ----- ----- -----

	static bool ReadChoice(int indexLength, out int choiceIndex, string label = "Val: ")
	{
		choiceIndex = -1;
		Console.Write(label);
		string? input = Console.ReadLine();

		if (!int.TryParse(input, out int index) || index < 0 || index > indexLength)
			return false;

		choiceIndex = index - 1;
		return true;
	}

	static bool ReadChoiceYesNo(out bool choice, string label = "Val: ")
	{
		string[] arr = ["Ja", "Nej"];
		choice = false;

		ShowMenuUI(null, arr);
		return ReadChoice(arr.Length, out int i, label) && i == 0;
	}

	static void ShowMenuUI(string? label, string[] choices)
	{
		if (!string.IsNullOrWhiteSpace(label))
			Console.WriteLine(label);

		for (int i = 0; i < choices.Length; i++)
			Console.WriteLine($"{i + 1}) {choices[i]}");
	}

	[GeneratedRegex("^[a-öA-Ö ]+$")]
	private static partial Regex LetersAndSpaces();

	[GeneratedRegex("^[0-9]{8}-[0-9]{4}$")]
	private static partial Regex SSN();
}