using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] PlayerState[] states;

    Animator animator;

    PlayerController player;

    PlayerInput input;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        player = GetComponent<PlayerController>();

        input = GetComponent<PlayerInput>();

        stateTable = new Dictionary<System.Type, IState>(states.Length);

        foreach (var state in states)
        {
            state.Initialize(animator,player,input,this);
            stateTable.Add(state.GetType(), state);
        }
    }

    void Start()
    {
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);
    }
}
