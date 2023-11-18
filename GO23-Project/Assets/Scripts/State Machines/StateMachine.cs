using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State currentState { get; private set; }

    public void Iniitialize(State initialState){
        currentState = initialState;
        currentState.Enter();
    }

    public void ChangeState(State newState){
        if(currentState == newState) return;
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

}
