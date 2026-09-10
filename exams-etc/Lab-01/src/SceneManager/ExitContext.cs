struct ExitContext(IScene? newScene, bool keepAlive = false)
{
	public IScene? NewScene = newScene;
	public bool KeepAlive = keepAlive;
}