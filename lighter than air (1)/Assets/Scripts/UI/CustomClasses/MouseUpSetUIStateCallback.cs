using UnityEngine;
using System.Collections;

public class MouseUpSetUIStateCallback : UI_MouseUpCallback
{
	//The UI Manager
	public UI_Manager uiManager;

	//The next UI state
	public int nextUIState;

	//Called when the left mouse button is released on the button this script is attached to
	public override void OnLeftMouseButtonUp()
	{
		//Set the UI State to the next UI State
		uiManager.SetState(nextUIState);
	}
}
