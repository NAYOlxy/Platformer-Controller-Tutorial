using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryGem : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelClearedEventChannel;
    [SerializeField] AudioClip pickUpSound;
    [SerializeField] ParticleSystem pickUpVFX;

    void OnTriggerEnter(Collider collision)
    {
        levelClearedEventChannel.Broadcast();
        SoundEffectsPlayer.audioSource.PlayOneShot(pickUpSound);
        Instantiate(pickUpVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
