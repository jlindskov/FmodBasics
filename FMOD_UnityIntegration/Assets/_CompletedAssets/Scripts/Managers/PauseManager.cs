﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {
	
	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot unpaused;

	public List<GameObject> objsToTurnOn;
	public MusicManager musicManager; 

	Canvas canvas;
	
	void Awake()
	{
		canvas = GetComponent<Canvas>();
		DisableGameObjects(); 
		canvas.enabled = true; 
	}

	public void StartGame()
	{
		foreach (GameObject gameobj in objsToTurnOn)
		{
			gameobj.SetActive(true);
		}

		musicManager.StartGameMusic();
		canvas.enabled = false;
	}
	
	public void DisableGameObjects()
	{
		foreach (GameObject gameobj in objsToTurnOn)
		{
			gameobj.SetActive(false);
		}
	}
	
	
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			canvas.enabled = !canvas.enabled;
			Pause();
		}
	}
	
	public void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		Lowpass ();
		
	}
	
	void Lowpass()
	{
		if (Time.timeScale == 0)
		{
			paused.TransitionTo(.01f);
		}
		
		else
			
		{
			unpaused.TransitionTo(.01f);
		}
	}
	
	public void Quit()
	{
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
}
