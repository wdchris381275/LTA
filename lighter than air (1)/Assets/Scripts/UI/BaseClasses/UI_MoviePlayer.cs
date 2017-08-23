using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_MoviePlayer : MonoBehaviour
{
	//The number of frames to play per second
	public float framesPerSecond = 24.0f;

	//Array of images (Movie)
	public Sprite[] frames;

	//The image to render the frames to
	private Image renderImage;

	//The frame time
	private float frameTime = 1.0f;

	//The current frame
	private int currentFrame = 0;

	//Called on initialization
	void Awake()
	{
		//Initialize UI MoviePlayer
		renderImage = GetComponent<Image>();

		//If there is atleast one frame
		if(frames.Length > 0)
		{
			//Set the render images current frame to the first frame in the movie
			renderImage.overrideSprite = frames[currentFrame];
		}
	}

	//Called once per frame
	void Update()
	{
		//Decrement the frame time
		frameTime -= framesPerSecond * Time.deltaTime;

		//If the frame time is equal to or under zero
		if (frameTime <= 0.0f)
		{
			//Increment the current frame
			currentFrame++;

			//If the current frame is out of bounds of the frames
			if (frames.Length - 1 < currentFrame)
			{
				//Set the current frame to the first frame in the movie
				currentFrame = 0;
			}

			//Reset the frame time
			frameTime = 1.0f - Mathf.Abs(frameTime);
		}

		//Set the render images texture to the current frame
		renderImage.overrideSprite = frames[currentFrame];
	}
}
