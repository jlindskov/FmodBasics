using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class MusicManager : MonoBehaviour
{

    [EventRef]
    public string music;

    private EventInstance musicInstance;

    public void Start()
    {
        musicInstance = RuntimeManager.CreateInstance(music);
        musicInstance.start();
    }


    public void StartGameMusic()
    {
        musicInstance.setParameterByName("GameStarted", 1); 
    }

    public void PlayerHalfHealth()
    {
        musicInstance.setParameterByName("HalfHealth", 1); 
    }

    public void PlayerDied()
    {
        musicInstance.setParameterByName("IsDead", 1);
    }


    private void OnDestroy()
    {
        musicInstance.stop(STOP_MODE.ALLOWFADEOUT);
        musicInstance.release(); 
    }
}
