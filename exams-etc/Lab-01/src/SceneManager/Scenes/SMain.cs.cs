class SMain : IScene
{
	public void Enter()
	{
		Loop();
	}

	public void Loop()
	{
		Console.WriteLine("VÄLKOMMEN TILL LASSES LAST 1.0\n");
		Console.WriteLine("1) Beräkna frakt för ett paket");
		Console.WriteLine("2) Beräkna frakt för flera paket från fil");
		Console.WriteLine("3) Avsluta\n");
		Console.Write("Val: ");

		string input = Console.ReadLine()!;

		switch (input)
		{
			// Do freaky stuff here :* 
		}
	}

	public void Exit()
	{
		throw new NotImplementedException();
	}
}