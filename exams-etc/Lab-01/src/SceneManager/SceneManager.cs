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
		if (_sceneHistory.Count > 0 && !keepOld)
			_sceneHistory.Pop()?.Exit();

		_sceneHistory.Push(newScene);
		_sceneHistory.Peek().Enter();
	}

	public static void GoBack()
	{
		if (_sceneHistory.Count == 1)
			return;

		_sceneHistory.Pop();
		_sceneHistory.Peek()?.Enter();
	}
}