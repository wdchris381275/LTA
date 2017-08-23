using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class UI_Slider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	//Whether the Slider handle should follow the mouse cursor on the horizontal axis
	public bool followHorizontal = true;

	//Whether the Slider handle should follow the mouse cursor on the vertical axis
	public bool followVertical = false;

	//The slider track the slider will stay on
	public Image sliderTrack;

	//The slider handle
	private Image sliderHandle;

	//The minimum position of the slider handle on the x-axis
	private float minimumPositionX;

	//The maximum position of the slider handle on the x-axis
	private float maximumPositionX;

	//The minimum position of the slider handle on the y-axis
	private float minimumPositionY;

	//The maximum position of the slider handle on the y-axis
	private float maximumPositionY;

	//Flag representing whether the slider handle should follow the mouse cursor
	private bool followMouseCursor = false;

	//Called on initialization
	void Awake()
	{
		//Initialize UI SliderHandle
		minimumPositionX = sliderTrack.rectTransform.position.x - sliderTrack.rectTransform.rect.width / 2.0f;
		maximumPositionX = sliderTrack.rectTransform.position.x + sliderTrack.rectTransform.rect.width / 2.0f;
		minimumPositionY = sliderTrack.rectTransform.position.y - sliderTrack.rectTransform.rect.height / 2.0f;
		maximumPositionY = sliderTrack.rectTransform.position.y + sliderTrack.rectTransform.rect.height / 2.0f;
		sliderHandle = GetComponent<Image>();
		sliderHandle.rectTransform.position = new Vector2(Mathf.Clamp(sliderHandle.rectTransform.position.x, minimumPositionX, maximumPositionX),
														  Mathf.Clamp(sliderHandle.rectTransform.position.y, minimumPositionY, maximumPositionY));
	}

	//Called once per frame
	void Update()
	{
		//If the slider handle should follow the mouse cursor
		if(followMouseCursor)
		{
			//If the slider should follow the mouse cursor on the horizontal axis
			if(followHorizontal)
			{
				//Move the slider handle to follow the mouse cursor on the x-axis
				sliderHandle.rectTransform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x, minimumPositionX, maximumPositionX),
																  sliderHandle.rectTransform.position.y);
			}

			//If the slider should follow the mouse cursor on the vertical axis
			if(followVertical)
			{
				//Move the slider handle to follow the mouse cursor on the y-axis
				sliderHandle.rectTransform.position = new Vector2(sliderHandle.rectTransform.position.x,
																  Mathf.Clamp(Input.mousePosition.y, minimumPositionY, maximumPositionY));
			}
		}
	}

	//Called when the left mouse button is down on the UI Button
	public void OnPointerDown(PointerEventData e)
	{
		//Set the follow mouse cursor flag to true
		followMouseCursor = true;
	}

	//Called when the left mouse button is up on the UI Button
	public void OnPointerUp(PointerEventData e)
	{
		//Set the follow mouse cursor flag to false
		followMouseCursor = false;
	}

	//Returns the percentage of the slider on the horizontal axis (Value will be between 0 and 1)
	public float EvaluateHorizontal()
	{
		//Calculate the minimum value the slider can be on the x-axis
		float minX = sliderTrack.rectTransform.position.x - sliderTrack.rectTransform.rect.width / 2.0f;

		//Calculate the maximum value the slider can be on the x-axis
		float maxX = sliderTrack.rectTransform.position.x + sliderTrack.rectTransform.rect.width / 2.0f;

		//Calculate the divisor for finding the sliders percentage on the x-axis
		float divisor = maxX - minX;

		//Calculate the sliders current progression through the slider track
		float sliderProgression = sliderHandle.rectTransform.position.x - minX;

		//If the slider progression is equal to zero
		if(sliderProgression == 0.0f)
		{
			//Return the percentage of the slider on the x-axis
			return 0.0f;
		}
		//Otherwise
		else
		{
			//Return the percentage of the slider on the x-axis
			return sliderProgression / divisor;
		}
	}

	//Returns the percentage of the slider on the vertical axis (Value will be between 0 and 1)
	public float EvaluateVertical()
	{
		//Calculate the minimum value the slider can be on the y-axis
		float minY = sliderTrack.rectTransform.position.y - sliderTrack.rectTransform.rect.height / 2.0f;

		//Calculate the maximum value the slider can be on the y-axis
		float maxY = sliderTrack.rectTransform.position.y + sliderTrack.rectTransform.rect.height / 2.0f;

		//Calculate the divisor for finding the sliders percentage on the y-axis
		float divisor = maxY - minY;

		//Calculate the sliders current progression through the slider track
		float sliderProgression = sliderHandle.rectTransform.position.y - minY;

		//If the slider progression is equal to zero
		if (sliderProgression == 0.0f)
		{
			//Return the percentage of the slider on the y-axis
			return 0.0f;
		}
		//Otherwise
		else
		{
			//Return the percentage of the slider on the y-axis
			return sliderProgression / divisor;
		}
	}
}
