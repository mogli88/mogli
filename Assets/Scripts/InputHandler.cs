using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	public GameObject background;
	public Material mat;
	public AudioClip purr;
	public AudioClip keyboard;
	private AudioSource audio;
	private Vector3 tmpMousePosition;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		audio.clip = keyboard;
		audio.Play ();
		tmpMousePosition = Input.mousePosition;
	}

	// Update is called once per frame
	void Update () {

//		if (Input.GetMouseButtonDown (0)) {
//			print ("Pressed");
//
//			if (tmpMousePosition != Input.mousePosition)
//			{
//				mat.color = new Color32 (150, 150, 150, 255);
//				audio.Stop ();
//				audio.clip = purr;
//				audio.Play();
//			}
//		}

		if (Input.GetMouseButtonUp (0)) {
			print ("Released");
			mat.color = new Color32 (65, 65, 65, 255);
			audio.Stop ();
			audio.clip = keyboard;
			audio.Play ();
		}

		if ((tmpMousePosition != Input.mousePosition) && (Input.GetMouseButtonDown (0))){
			Debug.Log("Mouse moved");
			tmpMousePosition = Input.mousePosition;

			mat.color = new Color32 (150, 150, 150, 255);
			audio.Stop ();
			audio.clip = purr;
			audio.Play();

		}

	}

}
