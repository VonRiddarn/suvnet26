using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

partial class Program
{
	// ----- ----- -----
	//	   FLOWS
	// ----- ----- -----
	static void CalculateTaxSingle()
	{
		StringBuilder uiAccumulative = new("Skatteuträkning för enskild individ\n");
		string? name = string.Empty;
		string? ssn = string.Empty;
		string? municipality = string.Empty;
		bool churchTaxed = false;
		DateTime birthDate;

		// TODO: DRY-ify code...
		while (string.IsNullOrEmpty(name) || !LetersAndSpaces().IsMatch(name))
		{
			Console.Clear();
			Console.WriteLine(uiAccumulative.ToString());
			Console.Write("Namn: ");
			name = Console.ReadLine();
		}

		uiAccumulative.Append($"\nNamn: {name}");

		while (
			string.IsNullOrEmpty(ssn) ||
			!SSN().IsMatch(ssn) ||
			!DateTime.TryParseExact(ssn[..^5], "yyyyMMdd", null, DateTimeStyles.None, out birthDate))
		{
			Console.Clear();
			Console.WriteLine(uiAccumulative.ToString());
			Console.Write("Personnummer (yyyymmdd-nnnn): ");
			ssn = Console.ReadLine()?.Trim();
		}

		// NOTE:
		// Even numbers also have even char-values. We are comparing the char
		// value in the modulus, not the actual user-inputed value.
		string gender = ssn[^2] % 2 == 0 ? "K" : "M";

		var today = DateTime.Today;

		int age = today.Year - birthDate.Year;
		if (today < birthDate.AddYears(age))
			age--;

		uiAccumulative.Append($" ({age}, {gender})");
		uiAccumulative.Append($"\nPersonnummer: {ssn[..^5]}-****");

		while (true)
		{
			Console.Clear();
			if (ReadChoiceYesNo(out churchTaxed))
				break;
		}
		uiAccumulative.Append($"\nKyrkomedlem: {(churchTaxed ? "Ja" : "Nej")}");

		Console.Clear();
		Console.WriteLine(uiAccumulative.ToString());
		Console.ReadLine();
	}

	static void CalculateTaxMultiple()
	{
		Console.WriteLine("CalculateTaxMultiple");
		Console.WriteLine("Press ENTER to continue...");
		Console.ReadLine();
	}

	static void Exit()
	{
		Environment.Exit(0);
	}
}