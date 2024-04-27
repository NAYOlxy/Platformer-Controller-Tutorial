using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGate : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelReadyEventChannel;

    void OnEnable()
    {
        levelReadyEventChannel.AddListener(OpenGate);
    }

    void OnDisable()
    {
        levelReadyEventChannel.RemoveListener(OpenGate);
    }

    void OpenGate()
    {
        Destroy(gameObject);
    }
}
