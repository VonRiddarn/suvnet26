class SOrderSingle : IScene
{
	public void Enter()
	{
		Loop();
	}

	public void Exit() { }

	static void Loop()
	{
		Console.WriteLine("Ayo, wassup! Imma head back to the menu once you press ENTER dawg.");
		Console.ReadLine();

		SceneManager.GoBack();
	}
}