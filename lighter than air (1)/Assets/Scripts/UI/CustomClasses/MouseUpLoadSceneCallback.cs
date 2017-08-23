using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MouseUpLoadSceneCallback : UI_MouseUpCallback
{
	//The scene to load when the button this script is attached to has the left mouse button release on
	public string nextScene = "Default";

	//Called when the left mouse button is released on the button this script is attached to
	public override void OnLeftMouseButtonUp()
	{
        //Set the scene to the next scene
        SceneManager.LoadScene(nextScene);
	}
}
