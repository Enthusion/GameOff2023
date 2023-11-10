using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInactiveState : PlayerState
{
    protected bool isSecondGrounded;
    public PlayerInactiveState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        playerController.Active = false;

    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        isSecondGrounded = playerController2.GroundCheck();
    }

    public override void Exit()
    {
        base.Exit();
        playerController.Active = true;
    }
}
