using UnityEngine;
using System.Collections;

public class MouseUpQuitCallback : UI_MouseUpCallback
{
	//Called when the left mouse button is released on the button this script is attached to
	public override void OnLeftMouseButtonUp()
	{
		//Quit the Game (Close the application)
		Application.Quit();	
	}
}
