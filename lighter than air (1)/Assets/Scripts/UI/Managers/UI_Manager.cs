using UnityEngine;
using System.Collections;

public class UI_Manager : MonoBehaviour
{
    //The state of the UI Manager
    public int state = 0;

    //The Mainmenu UI Canvas
    public Canvas mainmenuCanvas;

	//The Options UI Canvas
	public Canvas optionsCanvas;

    //The Loading UI Canvas
    public Canvas loadingCanvas;

    //Called on initialization
    void Awake()
    {
        //Disable each UI Canvas
        DisableAllUI();
    }

    //Called once per frame
    void Update()
    {
        //Set the State of the UI Manager
        SetState(state);
    }

    //Disables all the UI Canvas's
    private void DisableAllUI()
    {
        //Disable all UI canvas's
        mainmenuCanvas.enabled = false;
		optionsCanvas.enabled = false;
        loadingCanvas.enabled = false;
    }

    //Returns  the UI State
    public int GetState()
    {
        //Return the state of the UI Manager
        return state;
    }

    //Sets the UI state
    public void SetState(int newState)
    {
        //Disable all UI Canvas's
        DisableAllUI();

        //Depending on the state of the UI Manager
        switch (state)
        {
            //Display the Mainmenu UI
            case UI_State.Mainmenu:
                mainmenuCanvas.enabled = true;
                break;

			//Display the Options UI
			case UI_State.Options:
				optionsCanvas.enabled = true;
				break;

            //Display the Loading UI
            case UI_State.Loading:
                loadingCanvas.enabled = true;
                break;
        }

        //Set the UI Manager's state to the specified new state
        state = newState;
    }
}
