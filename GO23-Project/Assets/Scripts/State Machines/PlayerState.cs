using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    protected PlayerController playerController;
    protected string stateName;
    public PlayerState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine)
    {
        playerController = (PlayerController)controller;
        this.stateName = stateName;
    }

    public override void Enter()
    {
        base.Enter();
        playerController.Anima.SetBool(stateName, true);
    }

    public override void Exit()
    {
        base.Exit();
        playerController.Anima.SetBool(stateName, false);
    }
}
