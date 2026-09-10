class SOrderSingle : IScene
{
	public void Enter() { }

	public void Exit() { }

	public ExitContext Run()
	{
		Console.WriteLine("Ayo, wassup! Imma head back to the menu once you press ENTER dawg.");
		Console.ReadLine();

		return new(null);
	}
}