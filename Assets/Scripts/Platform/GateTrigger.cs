using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    [SerializeField] VoidEventChannel gateTriggerEventChannel;
    [SerializeField] AudioClip pickUpSound;
    [SerializeField] ParticleSystem pickUpVFX;


    void OnTriggerEnter(Collider collision)
    {
        gateTriggerEventChannel.Broadcast();
        SoundEffectsPlayer.audioSource.PlayOneShot(pickUpSound);
        Instantiate(pickUpVFX,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
