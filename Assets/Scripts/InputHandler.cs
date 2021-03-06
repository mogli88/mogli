﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

	public Material mat;
	public CameraShake cameraShake;
	public ParticleSystem p;
	Animator anim;
	public AudioClip purr;
	public AudioClip keyboard;
	private AudioSource audio;

	private Vector3 tmpMousePosition;

	private bool mouseClicked;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		audio.clip = keyboard;
		audio.Play ();
		tmpMousePosition = Input.mousePosition;

		//screen shake
		GameObject g = GameObject.Find ("Main Camera");
		cameraShake = g.GetComponent<CameraShake> ();
		//particles
		ParticleSystem p = GetComponent<ParticleSystem>();
		hideParticles ();
		//animations
		anim = GetComponent<Animator>();
		mouseClicked = false;
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
			anim.SetBool ("mouseClicked", false);
			mat.color = new Color32 (65, 65, 65, 255);
			audio.Stop ();
			audio.clip = keyboard;
			audio.Play ();
			cameraShake.mouseClicked = false;
			hideParticles ();

		}

		if ((tmpMousePosition != Input.mousePosition) && (Input.GetMouseButtonDown (0))){
			Debug.Log("Mouse moved");
			anim.SetBool ("mouseClicked", true);
			tmpMousePosition = Input.mousePosition;
			cameraShake.mouseClicked = true;
			seeParticles();
			mat.color = new Color32 (180, 180, 180, 255);
			audio.Stop ();
			audio.clip = purr;
			audio.Play();

		}

	}


	void seeParticles()
	{
		var main = p.main;
		main.startColor	= new Color (150, 150, 150, 250);
	}

	void hideParticles()
	{
		var main = p.main;
		main.startColor	= new Color (150, 150, 150, 0);
	}

}
