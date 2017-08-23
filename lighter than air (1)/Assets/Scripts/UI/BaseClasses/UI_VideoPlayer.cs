using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_VideoPlayer : MonoBehaviour
{
	//Called on initialization
	void Awake()
	{
		//Play the video
		((MovieTexture)GetComponent<Image>().material.mainTexture).Play();
	}
}
