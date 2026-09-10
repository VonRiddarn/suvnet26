using System;

namespace ConsoleAtHome;

public static partial class Cah
{
	public static class Input
	{
		/// <summary>
		/// Lock the user into an infinite loop until they provide a parseable string.
		/// </summary>
		/// <typeparam name="T">Return and parse type. ie: int</typeparam>
		public static T? ParseLine<T>(string prompt, bool clear = false) where T : IParsable<T>
		{
			while (true)
			{
				ClearAndPrompt(prompt, clear);

				if (T.TryParse(Console.ReadLine(), null, out T? result))
					return result;
			}
		}

		public static bool ParseYesNo(string prompt, bool clear = false)
		{
			string[] yesCol = ["ja", "yes", "y", "j", "1"];
			string[] noCol = ["nej", "no", "n", "0"];

			while (true)
			{
				ClearAndPrompt(prompt, clear);
				string? input = Console.ReadLine()?.ToLower();

				if (yesCol.Contains(input))
					return true;
				else if (noCol.Contains(input))
					return false;
			}
		}

		/// <summary>
		/// Force the user to enter a valid string from an array of strings.
		/// </summary>
		/// <returns>The index of the match.</returns>
		public static int ParseCustom(string prompt, string[] choices, bool clear = false)
		{
			while (true)
			{
				ClearAndPrompt(prompt, clear);
				string? input = Console.ReadLine();
				int index = choices.IndexOf(input, StringComparer.InvariantCultureIgnoreCase);

				if (index != -1)
					return index;
			}
		}

		public static T SelectFromIndex<T>(string prompt, T[] choices, int indexCorrection = 0, bool clear = false)
		{
			while (true)
			{
				ClearAndPrompt(prompt, clear);
				string? input = Console.ReadLine();

				if (int.TryParse(input, out int ix) && (ix + indexCorrection) >= 0 && (ix + indexCorrection) < choices.Length)
					return choices[ix + indexCorrection];
			}
		}

		// ----- ----- -----
		//		HELPERS
		// ----- ----- -----

		static void ClearAndPrompt(string prompt, bool clear)
		{
			if (clear)
				Console.Clear();

			Console.Write(prompt);
		}
	}
}