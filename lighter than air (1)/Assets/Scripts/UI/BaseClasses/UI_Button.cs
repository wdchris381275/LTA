using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class UI_Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    //Flag representing whether the mouse pointer is in the bounds of the UI Button
    private bool pointerInBounds = false;

    //The Image to replace the default image with when the mouse enters the bounds of the UI Button
    public Sprite mouseEnterImage = new Sprite();

    //The Image to replace the default image with when the mouse exits the bounds of the UI Button
    public Sprite mouseExitImage = new Sprite();

    //The Image to replace the default image with when the left mouse button is down on the UI Button
    public Sprite mouseDownImage = new Sprite();

	//The UI Button click sound effect
	public AudioClip ButtonClick;

	//Called when the mouse cursor enters the bounds of the UI Button
	public void OnPointerEnter(PointerEventData e)
    {
        //Replace the UI Button image with the mouse enter image
        GetComponent<Image>().sprite = mouseEnterImage;

        //Set the pointer in bounds flag
        pointerInBounds = true;
    }

    //Called when the mouse cursor exits the bounds of the UI Button
    public void OnPointerExit(PointerEventData e)
    {
        //Replace the UI Button image with the mouse exit image
        GetComponent<Image>().sprite = mouseExitImage;

        //Unset the pointer in bounds flag
        pointerInBounds = false;
    }

    //Called when the left mouse button is down on the UI Button
    public void OnPointerDown(PointerEventData e)
    {
        //Replace the UI Button image with the mouse down image
        GetComponent<Image>().sprite = mouseDownImage;

        //If the UI Button has a UI_MouseDownCallback script on it
        if(GetComponent<UI_MouseDownCallback>() != null)
        {
			//Call the mouse down callback function
			GetComponent<UI_MouseDownCallback>().OnLeftMouseButtonDown();
        }
    }

    //Called when the left mouse button is up on the UI Button
    public void OnPointerUp(PointerEventData e)
    {
        //If the mouse pointer is in the bounds of the UI Button
        if(pointerInBounds)
        {
            //Replace the UI Button image with the mouse enter image
            GetComponent<Image>().sprite = mouseEnterImage;
        }
        //Otherwise
        else
        {
            //Replace the UI Button image with the mouse exit image
            GetComponent<Image>().sprite = mouseExitImage;
        }

		//If the UI Button has a UI_MouseUpCallback script on it
		if (GetComponent<UI_MouseUpCallback>() != null)
		{
			//Call the mouse up callback function
			GetComponent<UI_MouseUpCallback>().OnLeftMouseButtonUp();
		}
	}
}