using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyScreen : MonoBehaviour
{
    [SerializeField] AudioClip startVoice;
    [SerializeField] VoidEventChannel levelReadyEventChannel;
    

    void LevelStart()
    {
        GetComponent<Canvas>().enabled = false;
        GetComponent<Animator>().enabled = false;

        levelReadyEventChannel.Broadcast();
    }

    void PlayStartVoice()
    {
        SoundEffectsPlayer.audioSource.PlayOneShot(startVoice); 
    }
}
