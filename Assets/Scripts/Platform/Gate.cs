using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] VoidEventChannel gateTriggerEventChannel;

    void OnEnable()
    {
        gateTriggerEventChannel.AddListener(Open);
    }

    void OnDisable()
    {
        gateTriggerEventChannel.RemoveListener(Open);
    }

    void Open()
    {
        Destroy(gameObject);
    }

}
