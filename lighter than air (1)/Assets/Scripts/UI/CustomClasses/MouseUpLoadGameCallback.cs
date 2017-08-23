using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MouseUpLoadGameCallback : UI_MouseUpCallback
{
	//The UI Manager
	public UI_Manager uiManager;

	//The next UI state
	public int loadingUIState;

	//The name of the Game scene level
	public string gameScene = "Default";

	//List of GameObjects to not destroy when loading the game scene
	public GameObject[] doNotDestroy;

	//Async operation object for loading the Game scene
	private AsyncOperation loadGameScene;

	//Called when the button this script is attached to has the left mouse button released
	public override void OnLeftMouseButtonUp()
	{
		//Set the UI State to the next UI State
		uiManager.SetState(loadingUIState);

		//For each GameObject that should not be deleted
		for (int gameObjectIndex = 0; gameObjectIndex < doNotDestroy.Length; gameObjectIndex++)
		{
			//Disable the GameObject being deleted during scene loading
			DontDestroyOnLoad(doNotDestroy[gameObjectIndex]);
		}

		//Start Loading the Game Scene
		StartCoroutine("LoadGameScene");

		//Enable the scene from activating
		loadGameScene.allowSceneActivation = true;
	}

	private IEnumerator LoadGameScene()
	{
		//Begin loading the Game scene
		loadGameScene = SceneManager.LoadSceneAsync(gameScene);

		//Disable the scene from immediately activating
		loadGameScene.allowSceneActivation = false;

		//Return from the function
		yield return loadGameScene;
	}
}
