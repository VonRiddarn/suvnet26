using System.Text;
using ConsoleAtHome;

class SOrderSingle : IScene
{
	public void Enter() { }

	public void Exit() { }

	public ExitContext Run()
	{
		string name;
		decimal kilos;
		decimal value;
		bool member;
		bool wantInsurance;

		StringBuilder accumulativeMenu = new("== Lasses last 1.0 || ENSKILD FRAKT\n");
		Console.Clear();
		Console.WriteLine(accumulativeMenu.ToString());

		// TODO: DRY this up later, obv.
		// Either through a repeatable method, 
		// or by using some dynamic wizard that iterates through properties

		name = Cah.Input.ReadLine("Namn: ");
		Console.Clear();
		Console.Write(accumulativeMenu.Append($"Namn: {name}\n").ToString());
		kilos = Cah.Input.ParseLine<decimal>("Vikt (kg): ");
		Console.Clear();
		Console.Write(accumulativeMenu.Append($"Vikt: {kilos} kg\n").ToString());
		value = Cah.Input.ParseLine<decimal>("Value (SEK): ");
		Console.Clear();
		Console.Write(accumulativeMenu.Append($"Value: {value} SEK\n").ToString());
		member = Cah.Input.ParseYesNo("Är du förmånsmedlem genom Lasse++ ? (y/n): ");
		Console.Clear();
		Console.Write(accumulativeMenu.Append($"Medlem: {(member ? "Ja" : "Nej")}\n").ToString());
		wantInsurance = Cah.Input.ParseYesNo("Vill du försäkra ditt paket? (y/n): ");
		Console.Clear();
		Console.Write(accumulativeMenu.Append($"Försäkra: {(wantInsurance ? "Ja" : "Nej")}\n").ToString());

		// This wont do jack all atm.
		Console.WriteLine("Stämmer detta? (ENTER)");
		Console.ReadLine();

		return new(null);
	}
}