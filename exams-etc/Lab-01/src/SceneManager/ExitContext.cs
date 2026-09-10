struct ExitContext(IScene? newScene, bool keepInHistory = false)
{
	public IScene? NewScene = newScene;
	public bool KeepInHistory = keepInHistory;
}