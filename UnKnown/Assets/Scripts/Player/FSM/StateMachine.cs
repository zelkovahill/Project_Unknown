using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StateMachine
{
    public IState CurrentState { get; private set; }
    

    public void Initialize(IState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }
}