using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    protected PlayerController playerController;
    public string stateName { get; private set; }
    public PlayerState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine)
    {
        playerController = (PlayerController)controller;
        this.stateName = stateName;
    }
}
