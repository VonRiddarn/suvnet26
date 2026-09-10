static class SceneManager
{
	static Stack<IScene> _sceneHistory = [];

	public static void ResetHstory(IScene scene)
	{
		_sceneHistory = [];
		_sceneHistory.Push(scene);
		_sceneHistory.Peek().Enter();
	}

	public static void SwitchScene(IScene newScene, bool keepOld = false)
	{
		bool isCurrent = _sceneHistory.Count > 0 && _sceneHistory.Peek() == newScene;

		if (_sceneHistory.Count > 0 && !isCurrent && !keepOld)
			_sceneHistory.Pop()?.Exit();

		if (!isCurrent)
			_sceneHistory.Push(newScene);

		_sceneHistory.Peek().Enter();

		// Run the new scene and store the exit context in ec
		var ec = _sceneHistory.Peek().Run();

		// If we are exiting to a new scene, we want to switch scene.
		// This can be a dive or replacement, hence the keepAlive passthrough.
		// If it is null, we assume backwards movement
		if (ec.NewScene != null)
			SwitchScene(ec.NewScene, ec.KeepAlive);
		else if (_sceneHistory.Count > 1)
		{
			_sceneHistory.Pop();
			SwitchScene(_sceneHistory.Peek());
		}
	}

	static void GoBack()
	{
		if (_sceneHistory.Count == 1)
			return;

		_sceneHistory.Pop();
		_sceneHistory.Peek()?.Enter();
	}
}