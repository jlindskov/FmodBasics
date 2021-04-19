using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class AudioAnimationHandler : MonoBehaviour
{

    public void PlaySound(string eventName)
    {
        RuntimeManager.PlayOneShot(eventName,this.transform.position);
    }
    
}
