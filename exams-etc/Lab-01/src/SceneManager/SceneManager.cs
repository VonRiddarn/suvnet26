static class SceneManager
{
	static readonly Stack<IScene> _sceneHistory = [];

	public static void Initialize(IScene startScene)
	{
		// First initialize
		_sceneHistory.Push(startScene);
		startScene.Enter();

		// When we have a scene in the stack, keep running the last item
		while (_sceneHistory.Count > 0)
		{
			var currentScene = _sceneHistory.Peek();

			var ec = currentScene.Run();

			// If we send back a scen context, check if we should kill the old context
			// And push the new one onto the stack
			// Else (we sent a null scnee context) pop the stack and initialize the previous scene
			// if we have scenes left
			if (ec.NewScene != null)
			{
				if (!ec.KeepInHistory)
					_sceneHistory.Pop()?.Exit();

				_sceneHistory.Push(ec.NewScene);
				ec.NewScene.Enter();
			}
			else
			{
				_sceneHistory.Pop()?.Exit();

				if (_sceneHistory.Count > 0)
					_sceneHistory.Peek().Enter();
			}
		}
	}
}