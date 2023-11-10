using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaitState : PlayerState
{
    public PlayerWaitState(Controller controller, StateMachine stateMachine, string stateName) : base(controller, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
        playerController.Active = false;

    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(Input.GetButtonDown("Swap") && playerController2.GroundCheck()){
            stateMachine.ChangeState(playerController.IdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        playerController.Active = true;
    }
}
