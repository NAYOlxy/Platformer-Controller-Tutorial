using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

public class OneWayPlatform : MonoBehaviour
{
    private bool isPlayerCan;
    private Rigidbody rb;
    private Transform playerTransform;
    public new BoxCollider collider;
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>(); 
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        isPlayerCan = (playerTransform.position.y < transform.position.y
            && playerTransform.position.x < transform.position.x + transform.localScale.x-1.0f
            && playerTransform.position.x > transform.position.x - transform.localScale.x+1.0f);
        if(isPlayerCan) 
        {
             collider.isTrigger = true;
        }
        else 
        {
            collider.isTrigger = false;
        }
    }

}
