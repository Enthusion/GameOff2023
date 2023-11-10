using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    protected PlayerController workingController;
    protected PlayerController playerController1;
    protected string stateName;
    public PlayerState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine)
    {
        playerController1 = (PlayerController)controller;
        this.stateName = stateName;
        workingController = playerController1;
    }

    public override void Enter()
    {
        base.Enter();
        workingController.Anima.SetBool(stateName, true);
    }

    public override void Exit()
    {
        base.Exit();
        workingController.Anima.SetBool(stateName, false);
    }
}
