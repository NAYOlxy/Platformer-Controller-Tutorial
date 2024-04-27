using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBall : MonoBehaviour
{
    [SerializeField] VoidEventChannel gateTriggerEventChannel;
    [SerializeField] float lifeTime = 1f;
    [SerializeField] ParticleSystem vfx;

    WaitForSeconds waitBallDestory;


    void OnEnable()
    {
        gateTriggerEventChannel.AddListener(OnGateTriggered);
        waitBallDestory = new WaitForSeconds(lifeTime);
    }

    

    void OnDisable()
    {
        gateTriggerEventChannel.RemoveListener(OnGateTriggered);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent(out PlayerController player))
        {
            player.OnDefeated();
        }
    }
    
    void OnGateTriggered()
    {
        StartCoroutine(nameof(waitBallDestoryCoroutine));
    }

    IEnumerator waitBallDestoryCoroutine()
    {
        yield return waitBallDestory;
        Instantiate(vfx,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
